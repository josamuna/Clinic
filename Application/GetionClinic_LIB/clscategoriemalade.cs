using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clscategoriemalade 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double  taux ;
  //***Listes***
  public List<clscategoriemalade> listes(){
 return clsMetier.GetInstance().getAllClscategoriemalade();
}
 public  List<clscategoriemalade>   listes(string criteria){
 return clsMetier.GetInstance().getAllClscategoriemalade(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClscategoriemalade(this);
 }
 public  int  update(clscategoriemalade varscls){
 return clsMetier.GetInstance().updateClscategoriemalade(varscls);
 }
 public  int  delete(clscategoriemalade varscls){
 return clsMetier.GetInstance().deleteClscategoriemalade(varscls);
 }
  //***Le constructeur par defaut***
  public    clscategoriemalade() 
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
  //***Accesseur de taux***
 public  double   Taux {

get { return taux; } 
set { taux = value; }
}

} //***fin class

} //***fin namespace
