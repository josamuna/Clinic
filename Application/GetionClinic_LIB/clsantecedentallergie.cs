using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsantecedentallergie 
{
  //***Les variables globales***
 private int   id ;
 private string   commentaire ;
 private int  id_allergie ;
 private int  id_malade ;

  //***Listes***
 public List<clsantecedentallergie> listes()
 {
     return clsMetier.GetInstance().getAllClsantecedentallergie();
 }
 public List<clsantecedentallergie> listes(int criteria)
 {
     return clsMetier.GetInstance().getAllClsantecedentallergie(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsantecedentallergie(this);
 }
 public int update(clsantecedentallergie varscls)
 {
     return clsMetier.GetInstance().updateClsantecedentallergie(varscls);
 }
 public int delete(clsantecedentallergie varscls)
 {
     return clsMetier.GetInstance().deleteClsantecedentallergie(varscls);
 }
 // //***Le constructeur par defaut***
 public clsantecedentallergie() 
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

public int Id_malade
{
  get { return id_malade; }
  set { id_malade = value; }
}
  //***Accesseur de Id_allergie***

public int Id_allergie
{
  get { return id_allergie; }
  set { id_allergie = value; }
}
public override string ToString()
{
    return commentaire;
}

} //***fin class

} //***fin namespace
