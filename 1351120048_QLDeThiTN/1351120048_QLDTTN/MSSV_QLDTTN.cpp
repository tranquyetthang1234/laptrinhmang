// MSSV_QLDTTN.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "CauhoiTN.h"
#include <vector>
#include <fstream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	vector<CauhoiTN> danhsachCauhoi;// chua cac cau hoi tren bo nho
	char chon;
	cout << "Chuong trinh QL De thi TN" << endl;
	do
	{
		cout << " ----------- Menu ---------\n";
		cout << " 0. Thoat\n";
		cout << " 1. Tao de thi moi\n";
		cout << " 2. Them cau hoi \n";
		cout << " 3. In danh sach cau hoi\n";
		cout << " 4. Ghi danh sach cau hoi ra file \n";
		cout << " 5. Doc danh sach cau hoi tu file \n";
		cout << " 6. Bat dau bai kiem tra \n";
		cout << " Moi chon: ";
		cin >> chon;
		fflush(stdin);
		CauhoiTN *cauhoimoi;
		static string tenfile;//Vì tên của file sẽ tự mất khi nhảy case switch bên dưới, nên dùng "static" để truy xuất được tên ở mọi case
		ofstream fo;
		ifstream fi;
		switch (chon)
		{
		case '1': danhsachCauhoi.clear(); //Xoa cac cau hoi hien co 
			break;
		case '2': //Nhap 1 cau hoi moi tu ban phim
			cauhoimoi = new CauhoiTN();
			if (danhsachCauhoi.size() == 0) //Nếu danh sách chưa có phần tử nào
			{
				cout << "Chua co cau hoi nao! Hay nhap cau hoi!" << endl;			
				cauhoimoi->nhap();
				danhsachCauhoi.push_back(*cauhoimoi);//câu hỏi chưa có trong đề thì cứ đẩy ra sau danh sách
			}
			//Chen vao danh sach
			else 
			{
				for (int i = 0; ; i++) //so sánh
				{
					if (danhsachCauhoi[i].giongnhau(cauhoimoi))
					{
						cout << "Cau hoi nay da co trong de thi!" << endl;
						break;
					}
					cauhoimoi->nhap();
					danhsachCauhoi.push_back(*cauhoimoi);
				}
			}
			break;
		case '3': //In danh sach
			cout << "Danh sach cau hoi: \n";
			for (int i = 0; i < danhsachCauhoi.size(); i++)
			{
				cout << " Cau hoi " << i + 1 /*i+1 để tránh trường hợp "câu hỏi 0", nghe không hay*/;
				danhsachCauhoi[i].xuat();
			}
			break;
		case '4':
			cout << " Nhap ten file: ";
			cin.ignore();
			getline(cin, tenfile);
			fo.open(tenfile);
			for (int i = 0; i < danhsachCauhoi.size(); i++)
				danhsachCauhoi[i].ghifile(fo);
			fo.close();
			break;
		case '5':
			if (tenfile.empty())//nếu tên file chưa được lưu trong bộ nhớ tạm hay chưa được người dùng nhập từ trước
			{
				cout << "Nhap vao ten file can mo: ";
				cin.ignore();
				getline(cin, tenfile);
			}
			cout << endl;
			fi.open(tenfile);
			cauhoimoi = new CauhoiTN();
			cauhoimoi->docfile(fi);
			break;
		case '6':
			if (danhsachCauhoi.size() == 0)
				cout << "Chua co cau hoi nao! Hay nhap cau hoi!" << endl;
			for (int i = 0; i < danhsachCauhoi.size(); i++)
			{
				cout << " Cau hoi " << i + 1;
				danhsachCauhoi[i].kiemtra();
			}
			break;
		default:
			break;
		}
	} while (chon != '0');
	system("pause");
	return 0;
}

