using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsaptitudephysique:clspersonne
{
  //***Les variables globales***
 private int   id ;
 private int   id_personne ;
 private int   id_province ;
 private int   id_districtville ;
 private int   id_territoirecommune ;
 private int   id_collectivitequartier ;
 private int age;
 private double poid;
 private double taille;
 private double perimetrethoracique;
 private double quotientvervaeck;
 private double indicepigment;
 private string remarque;
 private DateTime? dateexamen;

  //***Listes***
  public new List<clsaptitudephysique> listes(){
 return clsMetier.GetInstance().getAllClsaptitudephysique();
}
 public  new List<clsaptitudephysique>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsaptitudephysique(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsaptitudephysique(this);
 }
 public  int  update(clsaptitudephysique varscls){
 return clsMetier.GetInstance().updateClsaptitudephysique(varscls);
 }
 public  int  delete(clsaptitudephysique varscls){
 return clsMetier.GetInstance().deleteClsaptitudephysique(varscls);
 }
  //***Le constructeur par defaut***
  public    clsaptitudephysique() 
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
  //***Accesseur de id_province***
 public  int   Id_province {

get { return id_province; } 
set { id_province = value; }
}
  //***Accesseur de id_districtville***
 public  int   Id_districtville {

get { return id_districtville; } 
set { id_districtville = value; }
}
  //***Accesseur de id_territoirecommune***
 public  int   Id_territoirecommune {

get { return id_territoirecommune; } 
set { id_territoirecommune = value; }
}
  //***Accesseur de id_collectivitequartier***
 public  int   Id_collectivitequartier {

get { return id_collectivitequartier; } 
set { id_collectivitequartier = value; }
}
 //***Accesseur de age***
 public int Age
 {
     get { return age; }
     set { age = value; }
 }
 //***Accesseur de poid***
 public double Poid
 {
     get { return poid; }
     set { poid = value; }
 }
 //***Accesseur de taille***
 public double Taille
 {
     get { return taille; }
     set { taille = value; }
 }
 //***Accesseur de perimetrethoracique***
 public double Perimetrethoracique
 {
     get { return perimetrethoracique; }
     set { perimetrethoracique = value; }
 }
 //***Accesseur de quotientvervaeck***
 public double Quotientvervaeck
 {
     get { return quotientvervaeck; }
     set { quotientvervaeck = value; }
 }
 //***Accesseur de indicepigment***
 public double Indicepigment
 {
     get { return indicepigment; }
     set { indicepigment = value; }
 }
 //***Accesseur de dateexamen***
 public DateTime? Dateexamen
 {
     get { return dateexamen; }
     set { dateexamen = value; }
 }
  //***Accesseur de remarque***
 public  string   Remarque {

get { return remarque; } 
set { remarque = value; }
}

 public override string ToString()
 {
     return base.Nom_complet;
 }

} //***fin class

} //***fin namespace
