using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmouvementsysteme 
{
  //***Les variables globales***
 private int   id ;
 private string   commentaire ;
 private int   id_consultationprenatal ;
 private int   id_typesysteme ;
  //***Listes***
  public List<clsmouvementsysteme> listes(){
 return clsMetier.GetInstance().getAllClsmouvementsysteme();
}
 public  List<clsmouvementsysteme>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmouvementsysteme(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmouvementsysteme(this);
 }
 public  int  update(clsmouvementsysteme varscls){
 return clsMetier.GetInstance().updateClsmouvementsysteme(varscls);
 }
 public  int  delete(clsmouvementsysteme varscls){
 return clsMetier.GetInstance().deleteClsmouvementsysteme(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmouvementsysteme() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de commentaire***
 public  string   Commentaire {

get { return commentaire; } 
set { commentaire = value; }
}
  //***Accesseur de id_consultationprenatal***
 public  int   Id_consultationprenatal {

get { return id_consultationprenatal; } 
set { id_consultationprenatal = value; }
}
  //***Accesseur de id_typesysteme***
 public  int   Id_typesysteme {

get { return id_typesysteme; } 
set { id_typesysteme = value; }
}

} //***fin class

} //***fin namespace
