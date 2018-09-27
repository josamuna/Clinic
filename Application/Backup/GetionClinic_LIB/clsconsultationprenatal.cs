using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsconsultationprenatal 
{
  //***Les variables globales***
 private int   id ;
 private string   ddr ;
 private string   drp ;
 private string   entecedent ;
 private string   motif ;
 private string   historiquegrossesse ;
 private string   gropesanguin ;
 private string   rh ;
 private string   gesttte ;
 private string   parite ;
 private string   statuthemoglobique ;
 private bool?  conseiller ;
 private bool?  testee ;
 private bool?  oedeme ;
 private string   conjoctivepalpebrale ;
 private DateTime?  date ;
 private double   poid ;
 private double   temperature ;
 private double   pressionarterielle ;
 private int?  pouls ;
 private double?  taille ;
 private int   id_maladegrosse ;
 private int id_dossierconsultationprenatale;


  //***Listes***
  public List<clsconsultationprenatal> listes(){
 return clsMetier.GetInstance().getAllClsconsultationprenatal();
}
 public  List<clsconsultationprenatal>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsconsultationprenatal(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsconsultationprenatal(this);
 }
 public  int  update(clsconsultationprenatal varscls){
 return clsMetier.GetInstance().updateClsconsultationprenatal(varscls);
 }
 public  int  delete(clsconsultationprenatal varscls){
 return clsMetier.GetInstance().deleteClsconsultationprenatal(varscls);
 }
  //***Le constructeur par defaut***
  public    clsconsultationprenatal() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de ddr***
 public  string   Ddr {

get { return ddr; } 
set { ddr = value; }
}
  //***Accesseur de drp***
 public  string   Drp {

get { return drp; } 
set { drp = value; }
}
  //***Accesseur de entecedent***
 public  string   Entecedent {

get { return entecedent; } 
set { entecedent = value; }
}
  //***Accesseur de motif***
 public  string   Motif {

get { return motif; } 
set { motif = value; }
}
  //***Accesseur de historiquegrossesse***
 public  string   Historiquegrossesse {

get { return historiquegrossesse; } 
set { historiquegrossesse = value; }
}
  //***Accesseur de gropesanguin***
 public  string   Gropesanguin {

get { return gropesanguin; } 
set { gropesanguin = value; }
}
  //***Accesseur de rh***
 public  string   Rh {

get { return rh; } 
set { rh = value; }
}
  //***Accesseur de gesttte***
 public  string   Gesttte {

get { return gesttte; } 
set { gesttte = value; }
}
  //***Accesseur de parite***
 public  string   Parite {

get { return parite; } 
set { parite = value; }
}
  //***Accesseur de statuthemoglobique***
 public  string   Statuthemoglobique {

get { return statuthemoglobique; } 
set { statuthemoglobique = value; }
}
  //***Accesseur de conseiller***
 public  bool ?   Conseiller {

get { return conseiller; } 
set { conseiller = value; }
}
  //***Accesseur de testee***
 public  bool ?   Testee {

get { return testee; } 
set { testee = value; }
}
  //***Accesseur de oedeme***
 public  bool ?   Oedeme {

get { return oedeme; } 
set { oedeme = value; }
}
  //***Accesseur de conjoctivepalpebrale***
 public  string   Conjoctivepalpebrale {

get { return conjoctivepalpebrale; } 
set { conjoctivepalpebrale = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de poid***
 public  double   Poid {

get { return poid; } 
set { poid = value; }
}
  //***Accesseur de temperature***
 public  double   Temperature {

get { return temperature; } 
set { temperature = value; }
}
  //***Accesseur de pressionarterielle***
 public  double   Pressionarterielle {

get { return pressionarterielle; } 
set { pressionarterielle = value; }
}
  //***Accesseur de pouls***
 public  int ?   Pouls {

get { return pouls; } 
set { pouls = value; }
}
  //***Accesseur de taille***
 public  double ?   Taille {

get { return taille; } 
set { taille = value; }
}
  //***Accesseur de id_maladegrosse***
 public  int   Id_maladegrosse {

get { return id_maladegrosse; } 
set { id_maladegrosse = value; }
}

 //***Accesseur de id_dossierconsultationprenatale***
 public int Id_dossierconsultationprenatale
 {
     get { return id_dossierconsultationprenatale; }
     set { id_dossierconsultationprenatale = value; }
 }
 //***Accesseur de designation***
 public string Designation
 {
     get { return Id + "_" + Id_maladegrosse + "_" + Date ; }
 }

} //***fin class

} //***fin namespace
