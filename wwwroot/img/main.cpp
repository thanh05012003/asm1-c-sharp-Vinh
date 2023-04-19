#include <bits/stdc++.h>

struct SinhVien
{
    char hoten[50];
    char nganh[50];
    float diemC;
};

void nhapDanhSach(SinhVien sv[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("Moi nhap vao ten: ");
        fflush(stdin);
        fgets(sv[i].hoten, sizeof(sv[i].hoten), stdin);
        printf("Moi nhap vao nganh: ");
        fflush(stdin);
        fgets(sv[i].nganh, sizeof(sv[i].nganh), stdin);
        printf("Moi nhap diem C: ");
        scanf("%f", &sv[i].diemC);
    }
}
void Xuat(SinhVien sv[], int n)
{
    printf("danh sach sinh vien la: \n");
    for (int i = 0; i < n; i++)
    {
        printf("Ho ten: %s\n", sv[i].hoten);
        printf("Nganh: %s\n", sv[i].nganh);
        printf("Diem c: %f\n", sv[i].diemC);
    }
}
void timKiemTheoNganh(SinhVien sv[], int n)
{
    char nganh[50];
    printf("Moi nhap vao nganh");
    fflush(stdin);
    fgets(nganh, sizeof(nganh), stdin);
    for (int i = 0; i < n; i++)
    {
        if (strcmp(sv[i].nganh, nganh) == 0)
        {
            printf("Ho ten: %s\n", sv[i].hoten);
            printf("Nganh: %s\n", sv[i].nganh);
            printf("Diem c: %f\n", sv[i].diemC);
        }
    }
}

int main()
{
    SinhVien sv[5];
    int n;
    printf("Nhap so luong sv: ");
    scanf("%d", &n);
    nhapDanhSach(sv, n);
    Xuat(sv, n);
    printf("=========");
    timKiemTheoNganh(sv, n);
    return 0;
}