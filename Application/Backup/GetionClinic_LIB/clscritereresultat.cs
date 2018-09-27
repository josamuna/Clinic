using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
public class   clscritereresultat 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
 public List<clscritereresultat> listes()
 {
     return clsMetier.GetInstance().getAllClscritereresultat();
 }
 public List<clscritereresultat> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClscritereresultat(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClscritereresultat(this);
 }
 public int update(clscritereresultat varscls)
 {
     return clsMetier.GetInstance().updateClscritereresultat(varscls);
 }
 public int delete(clscritereresultat varscls)
 {
     return clsMetier.GetInstance().deleteClscritereresultat(varscls);
 }
  //***Le constructeur par defaut***
 public clscritereresultat() 
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
 public override string ToString()
 {
     return designation ;
 }
} //***fin class

} //***fin namespace
