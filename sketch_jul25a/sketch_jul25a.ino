int latchPin = 8;  // 74HC595のST_CPへ
int clockPin = 12; // 74HC595のSH_CPへ
int dataPin = 11;  // 74HC595のDSへ

int ledPin = 13;
char flag = 0;

unsigned int data = 6144;  // 0001 10000 00000 00
unsigned int data2 = 7372;  // 0001 11001 10011 00

void setup() {
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);

  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  /*
  // LED1からLED8までを順に光らせます
  for (int j = 0; j < 7; j++) {
    // 送信中のlatchPinはグランド(LOW)レベル
    digitalWrite(latchPin, LOW);
    // シフト演算を使って点灯するLEDを選択しています
    shiftOut(dataPin, clockPin, LSBFIRST, 1<<j);
    // 送信終了後latchPinをHIGHにする
    digitalWrite(latchPin, HIGH);
    delay(100);
  }
  */
  
  digitalWrite(latchPin, LOW);
  digitalWrite(dataPin, LOW);
  delay(1);
  //shiftOut(dataPin, clockPin, MSBFIRST, data << 8);
  //shiftOut(dataPin, clockPin, MSBFIRST, data);
  shiftOutTK(dataPin, clockPin, data);
  shiftOutTK(dataPin, clockPin, data2);
  delay(1);
  digitalWrite(latchPin, HIGH);
  
  flag = !flag;
  digitalWrite(ledPin, flag);
  delay(5000);
}

void shiftOutTK(int dataPin, int clockPin, unsigned int data)
{
  for(int i=15; i>=0; i--)
  {
    digitalWrite(dataPin, ((data >> i) & 1));
    Serial.print((data >> i) & 1);
    digitalWrite(clockPin, HIGH);
    delay(1);
    digitalWrite(clockPin, LOW);
    digitalWrite(dataPin, LOW);
  }
}

