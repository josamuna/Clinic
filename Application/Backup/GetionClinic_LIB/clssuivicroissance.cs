using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clssuivicroissance 
{
  //***Les variables globales***
 private int   id ;
 private int?  mois ;
 private int?  poid ;
 private DateTime?  date ;
 private int   id_maladeenconsultationpostnatal ;
  //***Listes***
  public List<clssuivicroissance> listes(){
 return clsMetier.GetInstance().getAllClssuivicroissance();
}
 public  List<clssuivicroissance>   listes(string criteria){
 return clsMetier.GetInstance().getAllClssuivicroissance(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClssuivicroissance(this);
 }
 public  int  update(clssuivicroissance varscls){
 return clsMetier.GetInstance().updateClssuivicroissance(varscls);
 }
 public  int  delete(clssuivicroissance varscls){
 return clsMetier.GetInstance().deleteClssuivicroissance(varscls);
 }
  //***Le constructeur par defaut***
  public    clssuivicroissance() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de mois***
 public  int ?   Mois {

get { return mois; } 
set { mois = value; }
}
  //***Accesseur de poid***
 public  int ?   Poid {

get { return poid; } 
set { poid = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de id_maladeenconsultationpostnatal***
 public  int   Id_maladeenconsultationpostnatal {

get { return id_maladeenconsultationpostnatal; } 
set { id_maladeenconsultationpostnatal = value; }
}
} //***fin class

} //***fin namespace
