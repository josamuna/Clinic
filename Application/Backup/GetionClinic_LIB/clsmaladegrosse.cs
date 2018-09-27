using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsmaladegrosse : clsmalade
{
  //***Les variables globales***
 private int   id ;
 private int   id_malade ;
 private string   conjoin ;
 private string   numeroregistre ;
  //***Listes***
  public new List<clsmaladegrosse> listes(){
 return clsMetier.GetInstance().getAllClsmaladegrosse();
}
 public  new List<clsmaladegrosse>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmaladegrosse(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsmaladegrosse(this);
 }
 public  int  update(clsmaladegrosse varscls){
 return clsMetier.GetInstance().updateClsmaladegrosse(varscls);
 }
 public  int  delete(clsmaladegrosse varscls){
 return clsMetier.GetInstance().deleteClsmaladegrosse(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmaladegrosse() 
{
}

  //***Accesseur de id***
 public  int   IdFemmeEnceinte {

get { return id; } 
set { id = value; }
}

 //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de conjoin***
 public  string   Conjoin {

get { return conjoin; } 
set { conjoin = value; }
}
  //***Accesseur de numeroregistre***
 public  string   Numeroregistre {

get { return numeroregistre; } 
set { numeroregistre = value; }
}

 public new string Nom_complet
 {
     get { return base.Nom + " " + base.Postnom + " " + base.Prenom; }
 }

} //***fin class

} //***fin namespace
