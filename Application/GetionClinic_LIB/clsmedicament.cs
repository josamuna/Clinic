using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmedicament 
{
  //***Les variables globales***
 private int   id ;
 protected string   desination ;
 private double?  pu ;
 private string   caracteristique ;
  //***Listes***
  public List<clsmedicament> listes(){
 return clsMetier.GetInstance().getAllClsmedicament();
}
 public  List<clsmedicament>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmedicament(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmedicament(this);
 }
 public  int  update(clsmedicament varscls){
 return clsMetier.GetInstance().updateClsmedicament(varscls);
 }
 public  int  delete(clsmedicament varscls){
 return clsMetier.GetInstance().deleteClsmedicament(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmedicament() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de desination***
 public  string   Desination {

get { return desination; } 
set { desination = value; }
}
  //***Accesseur de pu***
 public  double ?   Pu {

get { return pu; } 
set { pu = value; }
}
  //***Accesseur de caracteristique***
 public  string   Caracteristique {

get { return caracteristique; } 
set { caracteristique = value; }
}

} //***fin class

} //***fin namespace
