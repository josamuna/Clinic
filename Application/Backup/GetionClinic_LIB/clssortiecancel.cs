using System;
using System.Data;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clssortiecancel 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int id ;
 private int id_article ;
 private int id_sortie;
 private int? id_service;
 private int? id_malade;
 private DateTime? date ;
 private int? quantinte;
 private double? montant;
 private string etatpaiement;
 private bool sortiemalade;
 private int stock_in;

  //***Listes***
//  public List<clssortiecancel> listes(){
// return clsMetier.GetInstance().getAllClssortiecancel();
//}
 public List<clssortiecancel> listes(int criteria1,string criteria2){
 return clsMetier.GetInstance().getAllClssortiecancel(criteria1, criteria2);
}
 //public  List<clssortiecancel>   listes(string criteria){
 //return clsMetier.GetInstance().getAllClssortiecancel(criteria);
 //}
 //public  int  inserts(){
 //return clsMetier.GetInstance().insertClssortiecancel(this);
 //}
 //public  int  update(clssortiecancel varscls){
 //return clsMetier.GetInstance().updateClssortiecancel(varscls);
 //}
 //public  int  delete(clssortiecancel varscls){
 //return clsMetier.GetInstance().deleteClssortiecancel(varscls);
 //}
  //***Le constructeur par defaut***
 public clssortiecancel() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_article***
 public  int   Id_article {
get { return id_article; } 
set { id_article = value; }
}
 //***Accesseur de id_sortie***
 public int Id_sortie{
 get { return id_sortie; }
 set { id_sortie = value; }
 }
  //***Accesseur de id_service***
 public  int ?   Id_service {

get { return id_service; } 
set { id_service = value; }
}
 //***Accesseur de id_malade***
 public int? Id_malade
 {
     get { return id_malade; }
     set { id_malade = value; }
 }
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
 //***Accesseur de quantinte***
 public int? Quantinte{
    get { return quantinte; }
     set { quantinte = value; }
 }
 //***Accesseur de montant***
 public double? Montant
 {
     get { return montant; }
     set { montant = value; }
 }
 //***Accesseur de etatpaiement***
 public string Etatpaiement
 {
     get { return etatpaiement; }
     set { etatpaiement = value; }
 }
 //***Accesseur de sortiemalade***
 public bool Sortiemalade
 {
     get { return sortiemalade; }
     set { sortiemalade = value; }
 }
 //***Accesseur de stock_in***
 public int Stock_in
 {
     get { return stock_in; }
     set { stock_in = value; }
 }
} //***fin class

} //***fin namespace
