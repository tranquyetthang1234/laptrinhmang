#include "stdafx.h"
#include "CauhoiTN.h"
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

CauhoiTN::CauhoiTN()
{
}


CauhoiTN::~CauhoiTN()
{
}


void CauhoiTN::xuat()
{
	cout << endl << NoiDung << endl;
	cout << "a) " << CauHoiA << endl;
	cout << "b) " << CauHoiB << endl;
	cout << "* Dap an: " << CauDung << endl;
}


void CauhoiTN::nhap()
{
	cout << "Nhap noi dung cau hoi: ";
	cin.ignore();
	getline(cin, NoiDung);
	cout << " Nhap cau tra loi A: ";
	fflush(stdin);
	getline(cin, CauHoiA);
	cout << " Nhap cau tra loi B: ";
	fflush(stdin);
	getline(cin, CauHoiB);
	cout << " Cho biet cau nao dung (a/b): ";
	fflush(stdin);
	cin >> CauDung;
}


bool CauhoiTN::kiemtra()
{
	//Xuat cau hoi, nhan cau tra loi
	cout << endl << NoiDung << endl;
	cout << "a) " << CauHoiA << endl;
	cout << "b) " << CauHoiB << endl;
	char traloi;
	cout << " Chon a/b? ";
	cin >> traloi;
	if (toupper(traloi) == toupper(CauDung))//dùng to upper để đưa cả đáp án và câu trả lời về dạng in hoa, tránh trường hợp xung đột đáp án giữa 'A' và 'a'.
	{
		cout << " Ban tra loi dung!\n";
		return true;
	}
	else
	{
		cout << " Ban tra loi sai!\n";
		return false;
	}
}

bool CauhoiTN::giongnhau(CauhoiTN *cau)//câu hỏi đầu vào để so sánh
{
	if (this->NoiDung.compare(cau->NoiDung) != 0) // so sánh trả về khác 0 tức là nội dung 2 câu có sự khác nhau
		return false;
	return true; //giống nhau
}


void CauhoiTN::ghifile(ofstream& fo)
{
	fo << NoiDung << endl;
	fo << "a)" << CauHoiA << endl;
	fo << "b)" << CauHoiB << endl;
	fo << "*Dap an: " << CauDung << endl;
}

void CauhoiTN::docfile(ifstream& fi)
{
	string s;
	while (!fi.eof())//vòng lặp in nội dung file 
	{
		getline(fi, s);
		cout << s << endl;
	}
	fi.close();
}