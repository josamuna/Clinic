using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmaladiegynecologique 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
 public List<clsmaladiegynecologique> listes()
 {
     return clsMetier.GetInstance().getAllClsmaladiegynecologique();
 }
 public List<clsmaladiegynecologique> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsmaladiegynecologique(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsmaladiegynecologique(this);
 }
 public int update(clsmaladiegynecologique varscls)
 {
     return clsMetier.GetInstance().updateClsmaladiegynecologique(varscls);
 }
 public int delete(clsmaladiegynecologique varscls)
 {
     return clsMetier.GetInstance().deleteClsmaladiegynecologique(varscls);
 }
  //***Le constructeur par defaut***
 public clsmaladiegynecologique() 
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
