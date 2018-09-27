using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsechographie 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
 public List<clsechographie> listes()
 {
     return clsMetier.GetInstance().getAllClsechographie();
 }
 public List<clsechographie> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsechographie(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsechographie(this);
 }
 public int update(clsechographie varscls)
 {
     return clsMetier.GetInstance().updateClsechographie(varscls);
 }
 public int delete(clsechographie varscls)
 {
     return clsMetier.GetInstance().deleteClsechographie(varscls);
 }
  //***Le constructeur par defaut***
 public clsechographie() 
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
     return this.Designation;
 }

} //***fin class

} //***fin namespace
