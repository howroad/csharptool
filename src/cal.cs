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
			Console.Title = "��Ͻ��������v0.4 QQ436081860";

			while(true){

				try{
					hasResult = false;
					Console.WriteLine("�����������ֶ��Ÿ������س�ȷ����");

					string str = Console.ReadLine();

					string[] strArr = str.Split(',');

					a = Array.ConvertAll<string, decimal>(strArr, delegate (string s) {
						return decimal.Parse(s);
					});

					//Console.WriteLine(a);
					Console.WriteLine("����Ҫƥ��Ľ�����س�ȷ����");
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
						Console.WriteLine("--------���������AUTHOR:HOWROAD-----------");
					}else{
						Console.WriteLine("û�з��ϵĽ��!");
						Console.WriteLine("--------���������AUTHOR:HOWROAD-----------");
					}

					Console.WriteLine("���س���������");
				}catch{
					Console.WriteLine("������δ֪���󣬿����ǣ�1.��������� 2.û���ո�ʽ 3.���ֲ���ȷ 4.����2B");
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
								Console.Write("��" + (b[j] + 1) + "��");
								Console.ResetColor();
								Console.Write(" = ");
							}else{
								//ss += a[b[j]] + " + ";
								Console.Write(a[b[j]]);
								Console.ForegroundColor = ConsoleColor.Red;
								Console.Write("��" + (b[j] + 1) + "��");
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