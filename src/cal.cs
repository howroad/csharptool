using System;

namespace yhh
{
    class CalNum
    {
		static int N = 5;
		static int M = 3;
		static decimal[] a= new decimal[]{5,2,3,4,5};
		static int[] b = new int[M];
		static bool hasResult = false;
        static void Main()
        {
			Console.Title = "组合结果分析器v0.4 QQ436081860";

			while(true){

				try{
					hasResult = false;
					Console.WriteLine("输入所有数字逗号隔开，回车确定：");

					string str = Console.ReadLine();

					string[] strArr = str.Split(',');

					a = Array.ConvertAll<string, decimal>(strArr, delegate (string s) {
						return decimal.Parse(s);
					});

					//Console.WriteLine(a);
					Console.WriteLine("输入要匹配的结果，回车确定：");
					string str2 = Console.ReadLine();
					decimal result = decimal.Parse(str2);
					Console.WriteLine("---------------------------------");
					N = a.Length;
					for(int i = 1; i <= N; i++){
						M = i;
						b = new int[M];
						C(N,M,result);
					}
					if(hasResult){
						Console.WriteLine("--------计算结束：AUTHOR:HOWROAD-----------");
					}else{
						Console.WriteLine("没有符合的结果!");
						Console.WriteLine("--------计算结束：AUTHOR:HOWROAD-----------");
					}

					Console.WriteLine("按回车继续计算");
				}catch{
					Console.WriteLine("出现了未知错误，可能是：1.逗号输错了 2.没按照格式 3.数字不正确 4.我是2B");
					Console.WriteLine("--------AUTHOR:HOWROAD-----------");
				}

			}


        }
		static void C(int m,int n, decimal result){
			int i,j;
			for(i=n;i<=m;i++) {
				b[n-1] = i-1;

				if(n>1)
					C(i-1,n-1,result);
				else {
					//string ss = "";
					decimal sumNum = 0;
					for(j=0;j<=M-1;j++){
						//Console.Write(a[b[j]] + "  ");
						sumNum += a[b[j]];
					}
					if(sumNum == result){
						hasResult = true;
						for(j=0;j<=M-1;j++){
							if(j == M-1){
								//ss += a[b[j]] + " = ";
								Console.Write(a[b[j]]);
								Console.ForegroundColor = ConsoleColor.Red;
								Console.Write("【" + (b[j] + 1) + "】");
								Console.ResetColor();
								Console.Write(" = ");
							}else{
								//ss += a[b[j]] + " + ";
								Console.Write(a[b[j]]);
								Console.ForegroundColor = ConsoleColor.Red;
								Console.Write("【" + (b[j] + 1) + "】");
								Console.ResetColor();
								Console.Write(" + ");
							}

						}
						//ss += result;
						Console.Write(result);
						Console.WriteLine();
					}

				}
			}
		}
    }
}