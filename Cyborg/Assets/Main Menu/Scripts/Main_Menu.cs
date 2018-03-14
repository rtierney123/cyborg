using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour {
    public GameObject menu;
    private Animator anim;

    void Start() {
        anim = menu.GetComponent<Animator>();
        anim.enabled = false;
    }
    //Navbar slie animations
    public void menulevel() {
        anim.enabled = true;
        anim.Play("Menu-Level");
    }
    public void menucredits() {
        anim.enabled = true;
        anim.Play("Menu-Credits");
    }
    public void creditsmenu() {
        anim.enabled = true;
        anim.Play("Credits-Menu");
    }
    public void levelmenu() {
        anim.enabled = true;
        anim.Play("Level-Menu");
    }
}
