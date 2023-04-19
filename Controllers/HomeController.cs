using asm1_c_sharp.Models;
using asm1_c_sharp.Services;
using asm1_c_sharp.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingWebb.Services;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductServices _productServices;
    private readonly IUserServices userServices;
    private readonly ICartServices _cartServices;
    private readonly ICartDetailServices _cartDetailServices;

    public HomeController(ILogger<HomeController> logger, IProductServices productServices)
    {
        _logger = logger;
        _productServices = new ProductService();
        _cartServices = new CartServices();
        _cartDetailServices = new CartDetailsServices();
        userServices = new UserServices();
    }

    public IActionResult Index()
    {
        var products = _productServices.GetAllProduct();
        return View(products);
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Product()
    {
        var products = _productServices.GetAllProduct();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product, IFormFile imageFile)
    {
        if (imageFile != null && imageFile.Length > 0) // Không null và không trống
        {
            //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                imageFile.CopyTo(stream);
            }

            // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
            product.ImageUrl = imageFile.FileName;
        }

        if (_productServices.CreateProduct(product))
            return RedirectToAction(nameof(Product));
        else
            return BadRequest("Failed to create product.");
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var product = _productServices.GetProductById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (_productServices.UpdateProduct(product))
            return RedirectToAction(nameof(Product));
        else
            return BadRequest("Failed to update product.");
    }


    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        if (_productServices.DeleteProduct(id))
            return RedirectToAction(nameof(Product));
        else
            return BadRequest("Failed to delete product.");
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var product = _productServices.GetProductById(id);
        return View(product);
    }

    [HttpGet]
    public IActionResult ShowCart()
    {
        var userId = HttpContext.Session.GetString("dataUser");
        if (userId == null)
        {
            return View(null);
        }
        var cartView = _cartServices.GetCartView().Where(c =>c.UserId == Guid.Parse(userId));
      return View(cartView);
      
    }

    public IActionResult AddToCart(Guid id)
    {
        var product = _productServices.GetProductById(id);
        var dataUser = HttpContext.Session.GetString("dataUser");
        if (dataUser == null) return RedirectToAction("LogIn");
        var cart = _cartServices.GetCarts().FirstOrDefault(c => c.UserId == Guid.Parse(dataUser));
        var a = _cartDetailServices.GetCartDetail();
        if (cart == null)
        {
            var c = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(dataUser),
                Description = ""
            };
            _cartServices.CreateCart(c);
            var b = new CartDetails()
            {
                Idcart = c.Id,
                IdSP = product.ID,
                Quantity = 1
            };
            _cartDetailServices.CreateCartDetail(b);
            return RedirectToAction("ShowCart");
        }
        else
        {
            foreach (var item in a)
                if (item.IdSP == id && item.Idcart == cart.Id)
                {
                    var cartDetail = new CartDetails()
                    {
                        Idcart = cart.Id,
                        IdSP = product.ID,
                        Quantity = item.Quantity + 1
                    };
                    _cartDetailServices.UpdateCartDetails(cartDetail);
                    return RedirectToAction("ShowCart");
                }

            var cartDetails = new CartDetails()
            {
                Idcart = cart.Id,
                IdSP = product.ID,
                Quantity = 1
            };
            _cartDetailServices.CreateCartDetail(cartDetails);
            return RedirectToAction("ShowCart");
        }
    }


    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public IActionResult GioHang()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(User user)
    {
        var users = userServices.GetAllUser();
        user.Id = Guid.NewGuid();
        user.Status = "1";
        user.RoleId = Guid.Parse("7899f366-1993-4026-acbb-e6c18469d4cb");
        if (user != null)
            foreach (var item in users)
                if (item.Username == user.Username)
                {
                    return View();
                }
                else
                {
                    if (userServices.CreateUser(user)) return RedirectToAction("LogIn");
                }


        userServices.CreateUser(user);

        return RedirectToAction("LogIn");
    }

    public IActionResult LogIn()
    {
        HttpContext.Session.Remove("dataUser");
        return View();
    }

    [HttpPost]
    public IActionResult LogIn(User user)
    {
        var users = userServices.GetAllUser()
            .FirstOrDefault(c => c.Username == user.Username && c.Password == user.Password);

        if (users != null)
        {
            HttpContext.Session.SetString("dataUser", users.Id.ToString());
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult DeleteCart(Guid idPro)
    {
        return RedirectToAction("Index");
    }
}