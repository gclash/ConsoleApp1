using System;

class Program
{
    // 5.1 ประกาศตัวแปร
    static string[] menuName =
    {
        "เอสเปรสโซ",
        "อเมริกาโน",
        "ลาเต้",
        "คาปูชิโน",
        "มอคค่า"
    };

    static int[] menuPrice = { 40, 45, 55, 55, 60 };
    static int[] qtySold = new int[5];

    // 5.4 เมธอดคำนวณยอดขายรวม
    static int SumTotal(int[] qtySold, int[] menuPrice)
    {
        int total = 0;

        for (int i = 0; i < qtySold.Length; i++)
        {
            total += qtySold[i] * menuPrice[i];
        }

        return total;
    }

    // เมธอดสำหรับแสดงรายการเมนูกาแฟและราคา (เพิ่มเข้ามาเพื่อให้โค้ดสะอาดและเรียกใช้ง่าย)
    static void ShowCoffeeMenu()
    {
        Console.WriteLine("----------- รายการกาแฟ -----------");
        for (int i = 0; i < menuName.Length; i++)
        {
            Console.WriteLine("{0}. {1} (ราคา {2} บาท)", i + 1, menuName[i], menuPrice[i]);
        }
        Console.WriteLine("---------------------------------");
    }

    static void Main()
    {
        int choice = -1;

        // 5.2 เมนูหลัก
        while (choice != 0)
        {
            Console.WriteLine();
            Console.WriteLine("===== ระบบขายกาแฟ BEAN BAR =====");
            
            // แสดงรายการเมนูกาแฟและราคาให้เห็นในหน้าแรกเลย
            ShowCoffeeMenu(); 

            Console.WriteLine("[ เมนูระบบ ]");
            Console.WriteLine("1. ขายเมนู");
            Console.WriteLine("2. สรุปยอดขาย");
            Console.WriteLine("3. ค้นหาเมนูขายดี");
            Console.WriteLine("0. ออกจากโปรแกรม");
            Console.Write("เลือกเมนู : ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("กรุณากรอกตัวเลขเท่านั้น");
                continue;
            }

            // 5.3 เมนูที่ 1 ขายเมนู
            if (choice == 1)
            {
                int menuNo;

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== หน้าต่างการขาย =====");
                    // แสดงเมนูซ้ำอีกครั้งเพื่อให้พนักงานดูหมายเลขเมนู (1-5) ได้สะดวกตอนคีย์ข้อมูล
                    ShowCoffeeMenu(); 
                    
                    Console.Write("หมายเลขเมนูที่ต้องการขาย (1-5) : ");

                    if (!int.TryParse(Console.ReadLine(), out menuNo))
                    {
                        Console.WriteLine("กรุณากรอกตัวเลข 1-5 เท่านั้น");
                        continue;
                    }

                    if (menuNo >= 1 && menuNo <= 5)
                    {
                        break;
                    }

                    Console.WriteLine("ไม่มีเมนูนี้ กรุณากรอกหมายเลข 1-5 ใหม่");
                }

                int index = menuNo - 1;

                Console.Write("จำนวนแก้วที่ขาย : ");
                int qty;

                while (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                {
                    Console.Write("กรุณากรอกจำนวนแก้วที่มากกว่า 0 : ");
                }

                int money = menuPrice[index] * qty;
                qtySold[index] += qty;

                Console.WriteLine();
                Console.WriteLine(
                    "-> ขาย {0} จำนวน {1} แก้ว เป็นเงิน {2} บาท สำเร็จ!",
                    menuName[index],
                    qty,
                    money
                );
            }

            // 5.5 เมนูที่ 2 สรุปยอดขาย
            else if (choice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("===== สรุปยอดขาย =====");

                for (int i = 0; i < menuName.Length; i++)
                {
                    int total = qtySold[i] * menuPrice[i];

                    Console.WriteLine(
                        "{0} ราคา {1} บาท จำนวนที่ขาย {2} แก้ว เป็นเงิน {3} บาท",
                        menuName[i],
                        menuPrice[i],
                        qtySold[i],
                        total
                    );
                }

                int sum = SumTotal(qtySold, menuPrice);

                Console.WriteLine("------------------------------");
                Console.WriteLine("ยอดขายรวมทั้งหมด : {0} บาท", sum);

                // จัดระดับผลประกอบการ
                if (sum >= 3000)
                {
                    Console.WriteLine("ระดับผลประกอบการ : ยอดเยี่ยม");
                }
                else if (sum >= 1500)
                {
                    Console.WriteLine("ระดับผลประกอบการ : ดี");
                }
                else if (sum >= 500)
                {
                    Console.WriteLine("ระดับผลประกอบการ : พอใช้");
                }
                else
                {
                    Console.WriteLine("ระดับผลประกอบการ : ต้องปรับปรุง");
                }
            }

            // 5.6 เมนูที่ 3 ค้นหาเมนูขายดี
            else if (choice == 3)
            {
                int maxQty = 0;
                int maxIndex = -1;

                for (int i = 0; i < qtySold.Length; i++)
                {
                    if (qtySold[i] > maxQty)
                    {
                        maxQty = qtySold[i];
                        maxIndex = i;
                    }
                }

                if (maxIndex == -1 || maxQty == 0)
                {
                    Console.WriteLine("ยังไม่มีข้อมูลการขาย");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("===== เมนูขายดี =====");
                    Console.WriteLine(
                        "เมนูขายดีที่สุด : {0}",
                        menuName[maxIndex]
                    );
                    Console.WriteLine(
                        "จำนวนที่ขายได้ : {0} แก้ว",
                        maxQty
                    );
                }
            }

            // 5.2 ออกจากโปรแกรม
            else if (choice == 0)
            {
                Console.WriteLine();
                Console.WriteLine("ออกจากโปรแกรม...");
            }

            else
            {
                Console.WriteLine("กรุณาเลือกเมนู 0-3 เท่านั้น");
            }
        }
    }
}
