using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clscategoriechambre 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  prix ;
  //***Listes***
  public List<clscategoriechambre> listes(){
 return clsMetier.GetInstance().getAllClscategoriechambre();
}
 public  List<clscategoriechambre>   listes(string criteria){
 return clsMetier.GetInstance().getAllClscategoriechambre(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClscategoriechambre(this);
 }
 public  int  update(clscategoriechambre varscls){
 return clsMetier.GetInstance().updateClscategoriechambre(varscls);
 }
 public  int  delete(clscategoriechambre varscls){
 return clsMetier.GetInstance().deleteClscategoriechambre(varscls);
 }
  //***Le constructeur par defaut***
  public    clscategoriechambre() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de designation***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}
  //***Accesseur de prix***
 public  double ?   Prix {

get { return prix; } 
set { prix = value; }
}

} //***fin class

} //***fin namespace
