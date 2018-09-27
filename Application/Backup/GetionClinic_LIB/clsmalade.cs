using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsmalade : clspersonne
{
  //***Les variables globales***
 private int   id ;
 private int   id_personne ;
 private int   id_categoriemalade ;
 private int   id_etablissement ;
 private int   id_airsante ;
 private int   id_profession ;
 private string numero;
 private string numero_fiche;
 private int id_groupesanguin;

  //***Listes***
  public new List<clsmalade> listes(){
 return clsMetier.GetInstance().getAllClsmalade();
}
 public  new List<clsmalade>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmalade(criteria);
 }
 public  List<clsmalade>   listes1(string criteria){
 return clsMetier.GetInstance().getAllClsmaladeFeminin(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsmalade(this);
 }
 public  int  update(clsmalade varscls){
 return clsMetier.GetInstance().updateClsmalade(varscls);
 }
 public  int  delete(clsmalade varscls){
 return clsMetier.GetInstance().deleteClsmalade(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmalade() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_personne***
 public  int   Id_personne {

get { return id_personne; } 
set { id_personne = value; }
}
  //***Accesseur de id_categoriemalade***
 public  int   Id_categoriemalade {

get { return id_categoriemalade; } 
set { id_categoriemalade = value; }
}
  //***Accesseur de id_etablissement***
 public  int   Id_etablissement {

get { return id_etablissement; } 
set { id_etablissement = value; }
}
  //***Accesseur de id_airsante***
 public  int   Id_airsante {

get { return id_airsante; } 
set { id_airsante = value; }
}
  //***Accesseur de id_profession***
 public  int   Id_profession {

get { return id_profession; } 
set { id_profession = value; }
}
  //***Accesseur de numero***
 public  string   Numero {

get { return numero; } 
set { numero = value; }
}
 //***Accesseur de numero_fiche***
 public string Numero_fiche
 {

     get { return numero_fiche; }
     set { numero_fiche = value; }
 }
 public override string ToString()
 {
     return base.Nom_complet;
 }

 public int Id_groupesanguin
 {
     get { return id_groupesanguin; }
     set { id_groupesanguin = value; }
 }
} //***fin class

} //***fin namespace
