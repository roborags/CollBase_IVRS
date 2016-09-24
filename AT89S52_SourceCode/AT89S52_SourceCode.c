#include<reg52.h>

void baud()
{
TMOD=0x20;
SCON=0x50;
TH1=0xfd;
TR1=1;
}

void tx(unsigned char x)
{
	while(TI==0);
	SBUF=x;
	TI=0;
}

void main()
{
baud();
while(1)
{
	if(P1==0x01)   
				   //output pins from MT8870 to the controller
	tx('1');
	else if(P1==0x02)
	tx('2');
	else if(P1==0x03)
	tx('3');
	else if(P1==0x03)
	tx('4');
	else if(P1==0x03)
	tx('5');
}
}
