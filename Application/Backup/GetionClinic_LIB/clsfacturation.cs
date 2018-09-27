using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsfacturation 
{
  //***Les variables globales***
 private int   id ;
 private int? numero_facture;
 private int id_malade;
 private int id_paiement;
 private int ? id_article_f;
 private int? id_article;
 private string designation;
 private string designation_service;
 private double?  pu ;
 private double? quantite;
 private double? montantpaye;
 private double? montantmituelle;
 private double? dette;
 private double? avance;
 private DateTime? date;
 private string nomComplet;
 private bool ismedicament;
 private bool isexamen;
 private bool solde;
 private bool soldemituelle;
 private int id_etablissement;
 private bool ispaiementmalade;

  //***Listes***
 public List<clsfacturation> listes()
 {
 return clsMetier.GetInstance().getAllClsfacturation();
}
 public List<clsfacturation> listes(string criteria)
 {
 return clsMetier.GetInstance().getAllClsfacturation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsfacturation(this);
 }
 public int update(clsfacturation varscls)
 {
 return clsMetier.GetInstance().updateClsfacturation(varscls);
 }
 public int delete(clsfacturation varscls)
 {
 return clsMetier.GetInstance().deleteClsfacturation(varscls);
 }
  //***Le constructeur par defaut***
 public clsfacturation() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
 //***Accesseur de numero_facture***
 public  int?   Numero_facture {

     get { return numero_facture; }
     set { numero_facture = value; }
}

 //***Accesseur de id_malade***
 public int Id_malade
 {
     get { return id_malade; }
     set { id_malade = value; }
 }
 //***Accesseur de designation***
 public  string  Designation {

     get { return designation; }
     set { designation = value; }
}
 //***Accesseur de id_article***
 public  int?   Id_article {

     get { return id_article; }
     set { id_article = value; }
}
  //***Accesseur de stock***
 public  double?   Pu {

get { return pu; } 
set { pu = value; }
}
 //***Accesseur de quantite***
 public double? Quantite
 {
     get { return quantite; }
     set { quantite = value; }
 }
 //***Accesseur de dette***
 public double? Dette
 {
     get { return dette; }
     set { dette = value; }
 }
 //***Accesseur de montantmituelle***
 public double? Montantmituelle
 {
     get { return montantmituelle; }
     set { montantmituelle = value; }
 }
 //***Accesseur de montantpaye***
 public double? Montantpaye
 {
     get { return montantpaye; }
     set { montantpaye = value; }
 }
 //***Accesseur de Id_paiement***
 public int Id_paiement
 {
     get { return id_paiement; }
     set { id_paiement = value; }
 } 
 //***Accesseur de avance***
 public double? Avance
 {
     get { return avance; }
     set { avance = value; }
 }
 //***Accesseur de Date***
 public DateTime? Date
 {
     get { return date; }
     set { date = value; }
 }
 //***Accesseur de nomComplet***
 public string NomComplet
 {
     get { return nomComplet; }
     set { nomComplet = value; }
 }
 //***Accesseur de id_article_f***
 public int ? Id_article_f
 {
     get { return id_article_f; }
     set { id_article_f = value; }
 }
 //***Accesseur de ismedicament***
 public bool Ismedicament
 {
     get { return ismedicament; }
     set { ismedicament = value; }
 }
 //***Accesseur de isexamen***
 public bool Isexamen
 {
     get { return isexamen; }
     set { isexamen = value; }
 }
 //***Accesseur de ispaiementmalade***
 public bool Ispaiementmalade
 {
     get { return ispaiementmalade; }
     set { ispaiementmalade = value; }
 }
 //***Accesseur de soldemituelle***
 public bool Soldemituelle
 {
     get { return soldemituelle; }
     set { soldemituelle = value; }
 }
 //***Accesseur de solde***
 public bool Solde
 {
     get { return solde; }
     set { solde = value; }
 }
 //***Accesseur de id_etablissement***
 public int Id_etablissement
 {
     get { return id_etablissement; }
     set { id_etablissement = value; }
 }
 //***Accesseur de designation_service***
 public string Designation_service
 {
     get { return designation_service; }
     set { designation_service = value; }
 }

 //public override string ToString()
 //{
 //    return nomComplet;
 //}
} //***fin class

} //***fin namespace
