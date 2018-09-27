using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clspaiement 
{
  //***Les variables globales***
 private int   id ;
 private int id_malade;
 private int? id_sortie;
 private int? id_dossierpreconsultation;
 private int? id_consultation;
 private int? id_consultationgyn;
 private int? id_dossierconsultationprenatale;
 private int? id_dossierconsultationpostnatal;
 private int? id_dossierechographie;
 private int? id_dossiersoin;
 private int? id_dossiernursing;
 private int? id_operation_laboratoire;
 private int? id_hospitalisation;
 private int? id_autrefraie;
 private int? id_subit;
 private int? id_accouchement;
 private DateTime? date;
 private double montantdu;
 private double montantpaye;
 private double montantmituelle;
 private double? dette;
 private bool archive;
 private bool mituelle;
 
  //***Listes***
  public List<clspaiement> listes(){
 return clsMetier.GetInstance().getAllClspaiement();
}
 public  List<clspaiement>   listes(string criteria){
 return clsMetier.GetInstance().getAllClspaiement(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClspaiement(this);
 }
 public  int  update(clspaiement varscls){
 return clsMetier.GetInstance().updateClspaiement(varscls);
 }
 public  int  delete(clspaiement varscls){
 return clsMetier.GetInstance().deleteClspaiement(varscls);
 }
  //***Le constructeur par defaut***
  public    clspaiement() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
 //***Accesseur de id_sortie***
 public int? Id_sortie
 {
     get { return id_sortie; }
     set { id_sortie = value; }
 }
 //***Accesseur de id_dossierpreconsultation***
 public int? Id_dossierpreconsultation
 {
     get { return id_dossierpreconsultation; }
     set { id_dossierpreconsultation = value; }
 }
 //***Accesseur de id_dossierechographie***
 public int? Id_dossierechographie
 {
     get { return id_dossierechographie; }
     set { id_dossierechographie = value; }
 }
 //***Accesseur de id_dossiersoin***
 public int? Id_dossiersoin
 {
     get { return id_dossiersoin; }
     set { id_dossiersoin = value; }
 }
 //***Accesseur de id_consultation***
 public int? Id_consultation
 {
     get { return id_consultation; }
     set { id_consultation = value; }
 }
 //***Accesseur de id_dossierconsultationprenatale***
 public int? Id_dossierconsultationprenatale
 {
     get { return id_dossierconsultationprenatale; }
     set { id_dossierconsultationprenatale = value; }
 }
 //***Accesseur de id_dossierconsultationpostnatal***
 public int? Id_dossierconsultationpostnatal
 {
     get { return id_dossierconsultationpostnatal; }
     set { id_dossierconsultationpostnatal = value; }
 }
 //***Accesseur de id_operation_laboratoire***
 public int? Id_operation_laboratoire
 {
     get { return id_operation_laboratoire; }
     set { id_operation_laboratoire = value; }
 }
 //***Accesseur de id_hospitalisation***
 public int? Id_hospitalisation
 {
     get { return id_hospitalisation; }
     set { id_hospitalisation = value; }
 }
 //***Accesseur de id_autrefraie***
 public int? Id_autrefraie
 {
     get { return id_autrefraie; }
     set { id_autrefraie = value; }
 }

 //***Accesseur de id_subit***
 public int? Id_subit
 {
     get { return id_subit; }
     set { id_subit = value; }
 }
 //***Accesseur de id_accouchement***
 public int? Id_accouchement
 {
     get { return id_accouchement; }
     set { id_accouchement = value; }
 }
 //***Accesseur de date***
 public DateTime? Date
 {

     get { return date; }
     set { date = value; }
 }
 //***Accesseur de montantdu***
 public double Montantdu
 {
     get { return montantdu; }
     set { montantdu = value; }
 }
 //***Accesseur de montantpaye***
 public  double   Montantpaye {

get { return montantpaye; }
set { montantpaye = value; }
}
 //***Accesseur de dette***
 public double? Dette
 {
     get { return dette; }
     set { dette = value; }
 }
 //***Accesseur de archive***
 public bool Archive
 {
     get { return archive; }
     set { archive = value; }
 }
 //***Accesseur de montantmituelle***
 public double Montantmituelle
 {
     get { return montantmituelle; }
     set { montantmituelle = value; }
 }
 //***Accesseur de mituelle***
 public bool Mituelle
 {
     get { return mituelle; }
     set { mituelle = value; }
 }

 //***Accesseur de id_consultationgyn***
 public int? Id_consultationgyn
 {
     get { return id_consultationgyn; }
     set { id_consultationgyn = value; }
 }
 //***Accesseur de id_dossiernursing***
 public int? Id_dossiernursing
 {
     get { return id_dossiernursing; }
     set { id_dossiernursing = value; }
 }
} //***fin class

} //***fin namespace
