using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsconsultationgynecologique 
{
  //***Les variables globales***
 private int   id ;
 private int id_dossierconsultationgynecologique;
 private DateTime ? ddr;
 private DateTime ? dpa;
 private DateTime? date_consultation;

 private int? id_critereecho;
 string examengyneco;
 string diagnostic;



  //***Listes***
  public List<clsconsultationgynecologique> listes(){
 return clsMetier.GetInstance().getAllClsconsultationgynecologique();
}
 public  List<clsconsultationgynecologique>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsconsultationgynecologique(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsconsultationgynecologique(this);
 }
 public  int  update(clsconsultationgynecologique varscls){
 return clsMetier.GetInstance().updateClsconsultationgynecologique(varscls);
 }
 public  int  delete(clsconsultationgynecologique varscls){
 return clsMetier.GetInstance().deleteClsconsultationgynecologique(varscls);
 }
  //***Le constructeur par defaut***
  public    clsconsultationgynecologique() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Dossier***
 public int Id_dossierconsultationgynecologique
 {
     get { return id_dossierconsultationgynecologique; }
     set { id_dossierconsultationgynecologique = value; }
 }

 public int? Id_critereecho
 {
     get { return id_critereecho; }
     set { id_critereecho = value; }
 }

 public string Examengyneco
 {
     get { return examengyneco; }
     set { examengyneco = value; }
 }

 public DateTime ? Dpa
 {
     get { return dpa; }
     set { dpa = value; }
 }
 public DateTime ? Ddr
 {
     get { return ddr; }
     set { ddr = value; }
 }

 public DateTime? Date_consultation
 {
     get { return date_consultation; }
     set { date_consultation = value; }
 }
 public string Diagnostic
 {
     get { return diagnostic; }
     set { diagnostic = value; }
 }
} //***fin class

} //***fin namespace
