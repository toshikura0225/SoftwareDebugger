const int POWER_FREQ = 60;                        // 電源周波数

const float CYCLE = 1.0 / POWER_FREQ * 1000;             // 周期
const int ON_SPAN = (int)(CYCLE / 2.0 - 2 + 0.5); // Highレベル時間（周期半分中の両端1msecはLow）

const int ON_COUNT_1 = 1;                       // Low→Highタイミング（AC_DET）
const int OFF_COUNT_1 = ON_COUNT_1 + ON_SPAN;   // High→Lowタイミング（AC_DET）

const int ON_COUNT_2 = (int)(ON_COUNT_1 + (CYCLE / 3.0));   // Low→Highタイミング（AC_DET_2）
const int OFF_COUNT_2 = ON_COUNT_2 + ON_SPAN;                     // High→Lowタイミング（AC_DET_2）


const int pinAC_DET = 2;    // AC_DETピン番号
const int pinAC_DET_2 = 3;  // AC_DET2ピン番号


void setup() {
  // put your setup code here, to run once:
  pinMode(pinAC_DET, OUTPUT);
  pinMode(pinAC_DET_2, OUTPUT);
  pinMode(13, OUTPUT);

  delay(100);
  digitalWrite(pinAC_DET, LOW);
  digitalWrite(pinAC_DET_2, LOW);
}

static int counter = 0;
static int blk = 0;
void loop() {
  // put your main code here, to run repeatedly:
  
  // ～AC_DET～
  if (counter == ON_COUNT_1)
  {
    digitalWrite(pinAC_DET, HIGH);
  }
  else if(counter == OFF_COUNT_1)
  {
    digitalWrite(pinAC_DET, LOW);
  }

  // ～AC_DET_2～
  if(counter == ON_COUNT_2)
  {
    digitalWrite(pinAC_DET_2, HIGH);
  }
  else if(counter == OFF_COUNT_2)
  {
    digitalWrite(pinAC_DET_2, LOW);
  }


  counter++;
  if(counter >= (int)(CYCLE + 0.5))
  {
    counter = 0;
  }

  blk++;
  if(blk == 500)
  {
    digitalWrite(13, HIGH);
  }
  else if(blk == 1000)
  {
    digitalWrite(13, LOW);
    blk = 0;
  }

  delay(1);
}
