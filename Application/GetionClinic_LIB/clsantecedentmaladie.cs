using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsantecedentmaladie 
{
  //***Les variables globales***
 private int   id ;
 private string   commentaire ;
 private int? id_maladie;
 private int?  id_malade ;

  //***Listes***
 public List<clsantecedentmaladie> listes()
 {
     return clsMetier.GetInstance().getAllClsantecedentmaladie();
 }
 public List<clsantecedentmaladie> listes(int criteria)
 {
     return clsMetier.GetInstance().getAllClsantecedentmaladie(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsantecedentmaladie(this);
 }
 public int update(clsantecedentmaladie varscls)
 {
     return clsMetier.GetInstance().updateClsantecedentmaladie(varscls);
 }
 public int delete(clsantecedentmaladie varscls)
 {
     return clsMetier.GetInstance().deleteClsantecedentmaladie(varscls);
 }
  //***Le constructeur par defaut***
 public clsantecedentmaladie() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de Commentaire***
public string Commentaire
{
  get { return commentaire; }
  set { commentaire = value; }
}
  //***Accesseur de Id_malade***

public int? Id_malade
{
  get { return id_malade; }
  set { id_malade = value; }
}
//***Accesseur de Id_maladie***
public int? Id_maladie
{
    get { return id_maladie; }
    set { id_maladie = value; }
}
public override string ToString()
{
    return Commentaire;
}

} //***fin class

} //***fin namespace
