using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsfournisseur : clspersonne
{
  //***Les variables globales***
 private int   id ;
 private int   id_personne ;
 private string   numero ;
  //***Listes***
  public new List<clsfournisseur> listes(){
 return clsMetier.GetInstance().getAllClsfournisseur();
}
 public  new List<clsfournisseur>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsfournisseur(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsfournisseur(this);
 }
 public  int  update(clsfournisseur varscls){
 return clsMetier.GetInstance().updateClsfournisseur(varscls);
 }
 public  int  delete(clsfournisseur varscls){
 return clsMetier.GetInstance().deleteClsfournisseur(varscls);
 }
  //***Le constructeur par defaut***
  public    clsfournisseur() 
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
  //***Accesseur de numero***
 public  string   Numero {

get { return numero; } 
set { numero = value; }
}

} //***fin class

} //***fin namespace
