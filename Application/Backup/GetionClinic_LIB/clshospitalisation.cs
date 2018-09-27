using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clshospitalisation 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  datedebut ;
 private DateTime?  datefin ;
 private int   id_malade ;
 private int   id_chambre ;
 private string etatpaiement;

  //***Listes***
  public List<clshospitalisation> listes(){
 return clsMetier.GetInstance().getAllClshospitalisation();
 }
 public  List<clshospitalisation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClshospitalisation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClshospitalisation(this);
 }
 public  int  update(clshospitalisation varscls){
 return clsMetier.GetInstance().updateClshospitalisation(varscls);
 }
 public  int  delete(clshospitalisation varscls){
 return clsMetier.GetInstance().deleteClshospitalisation(varscls);
 }
  //***Le constructeur par defaut***
  public    clshospitalisation() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de datedebut***
 public  DateTime ?   Datedebut {

get { return datedebut; } 
set { datedebut = value; }
}
  //***Accesseur de datefin***
 public  DateTime ?   Datefin {

get { return datefin; } 
set { datefin = value; }
}
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de id_chambre***
 public  int   Id_chambre {

get { return id_chambre; } 
set { id_chambre = value; }
}

 //***Accesseur de etatpaiement***
 public string Etatpaiement
 {
     get { return etatpaiement; }
     set { etatpaiement = value; }
 }
 public override string ToString()
 {
     return datedebut.ToString();
 }

} //***fin class

} //***fin namespace
