using System;

namespace UnicamFattoriale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stampo dei messaggi di cortesia per l'utente, così lo guido all'utilizzo del programma
            Console.WriteLine("Questo programma calcola il fattoriale di un numero");
            bool continua = true;
            while (continua)
            {
                Console.Write("Digita un numero intero (al massimo 170) e premi invio: ");
                //Console.ReadLine si mette in attesa che l'utente digiti qualcosa e prema invio.
                //Quando ha premuto invio, il testo che ha digitato lo assegno ad una variabile di tipo string.
                try
                {
                    string testoDigitatoDallUtente = Console.ReadLine();
                    if (testoDigitatoDallUtente == "") throw new FormatException(); // praticamente un goto nel catch giusto
                    if (testoDigitatoDallUtente.ToCharArray()[0] == '-')
                    {
                        Console.WriteLine("Non posso calcolare il fattoriale di numeri negativi.\n");
                        continue;
                    }
                    //Interpreto il testo come un numero intero
                    int numero = int.Parse(testoDigitatoDallUtente);
                    // a forza di trial-and-error, ho visto che per interi più grandi di 170 il risultato è 'Ôê×'
                    if (numero > 170)
                    {
                        Console.WriteLine("Spiacente, non posso calcolare il fattoriale per questo valore.\n");
                        continue;
                    }
                    //Calcolo il fattoriale e lo inserisco in una variabile di tipo double dato che il calcolo può portare a numeri molto grandi
                    double risultato = Fattoriale(numero);
                    //Stampo il risultato
                    Console.WriteLine("Il fattoriale di " + numero + " e' " + risultato + "\n");

                }
                catch (FormatException e)
                {
                    Console.WriteLine("L'input inserito non era un intero. L'esecuzione verra' terminata.\n");
                    continua = false;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("L'input inserito era un numero troppo grande per essere un intero a 16 bit.\n");
                    continue;
                }
            }
            Console.WriteLine("Premere un tasto per uscire...");
            //Attendo che l'utente prema un tasto prima di uscire 
            Console.ReadKey();
        }

        /*
         Metodo per eseguire il calcolo della funzione fattoriale. Implementazione ricorsiva.
         */
        static double Fattoriale(int fattore)
        {
            // il cast è safe perché ho già gestito il caso di numeri negativi
            if (fattore > 1) return fattore * Fattoriale(fattore - 1);
            return 1;
        }
    }
}
