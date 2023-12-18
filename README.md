# WPFstampante
Programma C# per la creazione di una stampante
## Problema assegnato:
Ci è stato assegnato di creare una stampante molto primordiale (al momento).
## Possibile codice ambiguo:
la classe *enum* serve semplicemente per dare un valore ai vari colori in modo crescente partendo da 0.
ricordo che il file è stato reso persistente grazie all'utilizzo di un file .xml
## Spiegazione:

Abbiamo creato due classi una chiamata *stampante* e una *pagina*. Dentro la *stampante* ci si trova solamente  la inizializzazione dei colori;

```C#
public class Stampante
{
    public enum Colore
    {
        C,
        M,
        Y,
        B
    }

    //Property (vari serbatoi)
    public int Ciano {  get; set; } //ciano?
    public int Magenta { get; set; }
    public int Yellow { get; set; }
    public int Black { get; set; }

    //cassetto di tutti i fogli proprerty
    public int Fogli {  get; set; }

//costruttore
 public Stampante()
    {
        Ciano = Magenta = Yellow = Black = 100;
        Fogli = 0;
    }
```
ed anche la possibilità di fare una stampa;

```C#
public bool Stampa(Pagina p) 
    {   //controllo se è disponibile fare una stampa
        if (Ciano >= p.Ciano && Magenta >= p.Magenta && Yellow >= p.Yellow && Black >= p.Yellow && Fogli > 0)
        {
            //scalo il colore
            Ciano -= p.Ciano;
            Magenta -= p.Magenta;
            Yellow -= p.Yellow;
            Black -= p.Black;

            //cavo un foglio
            Fogli--;
            return true;
        }
        //non è possibile stampare
        return false;
    }
```
ma anche controllare lo stato del colore e dei fogli e in caso riempirli del quantitativo richiesto (solo per i fogli i colori si riempiono del tutto).


```C# 
   //quantità di inchiostro presente nel serbatoio richiesto.
public int statoInchiostro(Colore colore)
    {
        if (colore == Colore.C) { return Ciano; }
        else if (colore == Colore.M) { return Magenta; }
        else if (colore == Colore.Y) { return Yellow; }
        else if (colore == Colore.B) { return Black; }
        //mando un eccezione se non trovo il colore richiesto
        throw new ArgumentException("Colore non valido.");
    }

//quantità di fogli rimanenti
public int statoCarta()
    {
        return Fogli;
    }
    
//refullo il colore richiesto
public void sostituisciColore(Colore colore) 
    {
        if (colore == Colore.C) { Ciano = 100; }
        else if (colore == Colore.M) { Magenta = 100; }
        else if (colore == Colore.Y) { Yellow = 100; }
        else if (colore == Colore.B) { Black = 100; }
    }

//aggiungo i fogli richiesti
public void aggiungiCarta(int quantita) 
    {
        if(Fogli == 200) 
        { throw new ArgumentException("Carta già piena!"); }

        Fogli += quantita;
    }

}
```
Nella classe *Pagina* invece chiediamo dei colori e stampiamo una pagina random.
```C#
public class Pagina
{
    public int Ciano { get; set; }
    public int Magenta { get; set; }
    public int Yellow { get; set; }
    public int Black { get; set; }

    //costruttore che accetta al massimo colori di valore 3
    public Pagina(int c, int m, int y, int b) 
    {
        if (c > 3 || m > 3 || y > 3 || b > 3)
        {
            throw new ArgumentException("I valori dei colori devono essere al massimo 3.");
        }

        Ciano = c;
        Magenta = m;
        Yellow = y;
        Black = b;
    }

    //costruttore che crea una pagina
    public Pagina()
    {
        Random rand = new Random();
        Ciano = rand.Next(4);
        Magenta = rand.Next(4);
        Yellow = rand.Next(4);
        Black = rand.Next(4);
    }
}
```

# Rappresentazione UML della classe 
<img src= "https://github.com/ThIsIsNoTFiNe/WPFStampante/assets/127590111/f910b150-3a7d-4f2f-aa0b-773a6b4059e5">
<img src= "https://github.com/ThIsIsNoTFiNe/WPFStampante/assets/127590111/2a0ff9b2-b15c-4ad1-9064-16fdefb997f1">
