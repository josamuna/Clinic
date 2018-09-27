using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsallergie 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
 public List<clsallergie> listes()
 {
     return clsMetier.GetInstance().getAllClsallergie();
 }
 public List<clsallergie> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsallergie(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsallergie(this);
 }
 public int update(clsallergie varscls)
 {
     return clsMetier.GetInstance().updateClsallergie(varscls);
 }
 public int delete(clsallergie varscls)
 {
     return clsMetier.GetInstance().deleteClsallergie(varscls);
 }
  //***Le constructeur par defaut***
 public clsallergie() 
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

} //***fin class

} //***fin namespace
