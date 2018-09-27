using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clscriterechographie 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
 public List<clscriterechographie> listes()
 {
 return clsMetier.GetInstance().getAllClscriterechographie();
}
 public List<clscriterechographie> listes(string criteria)
 {
 return clsMetier.GetInstance().getAllClscriterechographie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClscriterechographie(this);
 }
 public int update(clscriterechographie varscls)
 {
 return clsMetier.GetInstance().updateClscriterechographie(varscls);
 }
 public int delete(clscriterechographie varscls)
 {
 return clsMetier.GetInstance().deleteClscriterechographie(varscls);
 }
  //***Le constructeur par defaut***
 public clscriterechographie() 
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
