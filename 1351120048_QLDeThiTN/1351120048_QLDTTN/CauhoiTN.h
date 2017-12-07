#pragma once
#include <string>

using namespace std;
class CauhoiTN
{
private:
	string NoiDung;
	string CauHoiA;
	string CauHoiB;
	char CauDung;//A, B
public:
	CauhoiTN();
	~CauhoiTN();
	void xuat();
	void nhap();
	bool kiemtra();
	bool giongnhau(CauhoiTN *cau);
	void ghifile(ofstream& fo);
	void docfile(ifstream& fi);
};

