
using System;
using System.Data;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmouvementoperation_laboratoire 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private int   id_operation_laboratoire ;
 private int id_critere;
 private string   resultat ;
 private DateTime?  date ;
 private string examen_complet;
 private string critere_complet;

  //***Listes***
  public List<clsmouvementoperation_laboratoire> listes(){
 return clsMetier.GetInstance().getAllClsmouvementoperation_laboratoire();
}
 public  List<clsmouvementoperation_laboratoire>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmouvementoperation_laboratoire(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmouvementoperation_laboratoire(this);
 }
 public  int  update(clsmouvementoperation_laboratoire varscls){
 return clsMetier.GetInstance().updateClsmouvementoperation_laboratoire(varscls);
 }
 public  int  delete(clsmouvementoperation_laboratoire varscls){
 return clsMetier.GetInstance().deleteClsmouvementoperation_laboratoire(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmouvementoperation_laboratoire() 
{
}

  //***Accesseur de id***
public  int   Id {
get { return id; } 
set { id = value; }
}
  //***Accesseur de id_operation_laboratoire***
public  int   Id_operation_laboratoire {
    get { return id_operation_laboratoire; } 
    set { id_operation_laboratoire = value; }
}
  //***Accesseur de resultat***
public  string   Resultat {
    get { return resultat; } 
    set { resultat = value; }
}
  //***Accesseur de date***
public  DateTime ?   Date {
    get { return date; } 
    set { date = value; }
}
 //***Accesseur de id_critere***
public int Id_critere
{
    get { return id_critere; }
    set { id_critere = value; }
}


public string Examen_complet
{
    get { return examen_complet; }
    set { examen_complet = value; }
}

public string Critere_complet
{
    get { return critere_complet; }
    set { critere_complet = value; }
}
public override string ToString()
{
    return Date.ToString();
}
} //***fin class

} //***fin namespace
