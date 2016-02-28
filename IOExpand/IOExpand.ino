#include  <Wire.h>

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("started");
  
  Wire.begin(); // I2Cバスに接続
  delay(500);
  
  Wire.beginTransmission(0x20);	                // アドレスを7バイト換算
  Wire.write(0x06);				// I/O direction(ic0)
  Wire.write(0x00);				// ic0 directon
  Wire.write(0x00);				// ic1 directionを続けて送信しても可
  int a = Wire.endTransmission();		// 送信
  Serial.print(a);
  delay(200);
  
  /*
  Wire.beginTransmission(0x20);	 // アドレス44(0x2c)のデバイスに送信
  Wire.write(0x07);				// 1バイトをキューへ送信
  Wire.write(0x00);				// 1バイトをキューへ送信
  int b = Wire.endTransmission();		// 送信完了
  Serial.print(b);
  delay(200);
  */
}
bool flag = true;
void loop() {
  // put your main code here, to run repeatedly:

  // setup()を参照
  Wire.beginTransmission(0x20);
  Wire.write(0x02);
  Wire.write(flag ? 1 : 0);
  Wire.write(0x02);
  int b = Wire.endTransmission();
  Serial.print(b); 
  delay(1000);
  flag = !flag;

}
