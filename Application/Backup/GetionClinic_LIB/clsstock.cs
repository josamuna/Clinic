using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsstock 
{
  //***Les variables globales***
 private int   id ;
 private int   id_article ;
 private int   valeur ;
  //***Listes***
  public List<clsstock> listes(){
 return clsMetier.GetInstance().getAllClsstock();
}
 public  List<clsstock>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsstock(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsstock(this);
 }
 public  int  update(clsstock varscls){
 return clsMetier.GetInstance().updateClsstock(varscls);
 }
 public  int  delete(clsstock varscls){
 return clsMetier.GetInstance().deleteClsstock(varscls);
 }
  //***Le constructeur par defaut***
  public    clsstock() 
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
  //***Accesseur de valeur***
 public  int   Valeur {

get { return valeur; } 
set { valeur = value; }
}

} //***fin class

} //***fin namespace
