using System;
using System.Linq;



namespace A2.__Proposta_Pràctica_2._4.__Casino_Virtual_DW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Saldo inicial 
            double teuSaldo = 0;
            
            int respDelUsuari;
            bool unBucle = true;
            
            while (unBucle)
            {
               
                Console.WriteLine($"Saldo inicial: {teuSaldo}");
                if (teuSaldo == 1000.0)
                {
                    Console.WriteLine("No tens diners");
                    break;
                }
                Console.WriteLine("Benvingut al CASINO DW \n--------------------------------------");
                Console.WriteLine("Que vols jugar??? \n 1.Ruleta  2.màquines escurabutxaques  3.Carrera de caballs    4.Sortir \n SELECCIONA EL NUMERO ");
                
                respDelUsuari = Convert.ToInt32(Console.ReadLine());
                
                switch (respDelUsuari)
                {

                    case 1:
                        
                        Console.WriteLine("Ruleta");
                        Random unRandom = new Random();

                        //Listas para apostar casella
                        int[] casellaNegra =  {1,3,5,7,9,12,14,16,18,19,21,23,25,27,30,32,34,36}; 
                        int[] casellaVermella = {2,4,6,8,10,11,13,15,17,20,22,24,26,28,29,31,33,35 }; 
                        int numRandom;
                        numRandom = unRandom.Next(0, 36);
                        Console.WriteLine("Com vols apostar 1.Numero especific 2.Color de casella 3.Sortir ");
                        int ruleResposta = Convert.ToInt32(Console.ReadLine());
                        if (ruleResposta == 1)
                        {
                            //Selecciona  els modes de apostar 
                            
                            Console.WriteLine("Quin numero apostaras?");
                            int numApostat = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Quantitat que apostaras ?");
                            double unaQuantitat = Convert.ToDouble(Console.ReadLine());

                            if (numApostat == numRandom)
                            {
                                teuSaldo += unaQuantitat;
                                Console.WriteLine("Has Guanyat" + unaQuantitat);

                            }
                            else if(numApostat != numRandom)
                            {
                                Console.WriteLine("No has guanyat");
                                teuSaldo -= unaQuantitat;
                            }
                            
                           
                        }
                         else if (ruleResposta == 2)
                          {
                            
                            
                            Console.WriteLine("Quin color? posa-->(v->vermell, n:negre)");
                            char casellApostat = Convert.ToChar(Console.ReadLine());
                            Console.WriteLine("Quantitat que apostaras ?");
                            double unaQuantitat = Convert.ToDouble(Console.ReadLine());


                            //Saber si el numero random té el numero de la llista
                            bool esVermell = casellaVermella.Contains(numRandom);
                            bool esNegre = casellaNegra.Contains(numRandom);
                            //Condicional quan la resposta sigui igua a v i vermell i fem el mateix amb l0altre
                            if (casellApostat == 'v' && esVermell || casellApostat == 'n' && esNegre)
                            {
                                teuSaldo += unaQuantitat;
                                Console.WriteLine("Has guanyat");
                            }
                            else
                            {
                                teuSaldo -= unaQuantitat;
                                Console.WriteLine("Has perdut.");
                            }

                          
                          }

                        else if (ruleResposta == 3)
                        {
                            break;

                        }
                        break;

                    case 2:
                        Console.WriteLine("màquines escurabutxaques");
                        //Aqui fem una llista per  els elemnents que necessitarem
                        string[] unSimbol = { "cirera", "Llimon", "Taronja", "Bar", "7" };

                        // Número de carretes

                        Random altreRandom = new Random();
                        Console.WriteLine("Quant vols apostar? 1.Per sortir");
                        double respUser = Convert.ToDouble(Console.ReadLine());
                        if(respUser == 1 || teuSaldo == 0)
                        {
                            break;
                        }
                        
                        for (int i = 0; i < 3 /* Aqui posarem que té que repetir 3 cops*/; i++)
                        {
                            int donarSimbol = altreRandom.Next(unSimbol.Length); // Aquesta variable tindra acces a la llista i el seleccionara de manara aleatori
                            Console.WriteLine(unSimbol[donarSimbol]);
                        }

                        if (unSimbol[0] == unSimbol[1] && unSimbol[1] == unSimbol[2] )
                        {
                            teuSaldo += respUser;
                            Console.WriteLine("Has guanyat");

                        }
                        else
                        {
                            Console.WriteLine("Hs perdut");
                            teuSaldo -= respUser;
                        }

                        break;

                    case 3:
                        Console.WriteLine(" Carrera de Caballs simulat");
                        Console.WriteLine(" Numero que vols apotar del caball = 1,2,3,4");
                        int userCaball = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine(" Quantitat que vols");
                        double unDiners = Convert.ToDouble(Console.ReadLine());
                        int unaMeta = 5;
                      
                        int[] numCaball = { 1, 2, 3, 4 }; //identificador del caball
                        int[] unaPosicion = { 0, 0, 0, 0 }; // posicio inicial per cada caball 
                        Random bRandom = new Random();
                        Console.WriteLine("La carrera comença");
                        for (int i = 0;i < numCaball.Length;i++)
                        {
                            unaPosicion[i] = bRandom.Next(1,4 + 1);
                            Console.WriteLine("caball" + numCaball[i] +" " + "Posicio" + unaPosicion[i]);
                            if (!unaPosicion.Contains(numCaball[i])){


                                if (unaPosicion[i] >= unaMeta)
                                {
                                    Console.WriteLine("Has guanyat el caball" + " " + numCaball[i]);

                                    if (userCaball == numCaball[i])
                                    {
                                        Console.WriteLine("Has gunayat");
                                        teuSaldo += unDiners;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Has perdut ");
                                        teuSaldo -= unDiners;

                                    }
                                }
                            }
                           
                        }
                     
                        break;

                    case 4:
                        

                        unBucle = false;
                        Console.WriteLine($"Saldo Actual:{teuSaldo}");

                        break;

                }

            }
        }

        //Poner funciones si utilizo...
        
        

    }

}
