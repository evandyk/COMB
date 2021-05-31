using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour
{
    Animator m_Animator;
    public int Loadedammo = 6;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Loadedammo == 0 && this.transform.parent.GetComponent<Gun>().ammo != 0)
        {
            m_Animator.SetTrigger("Reload");
        }
        else if (Loadedammo == 0 && this.transform.parent.GetComponent<Gun>().ammo == 0)
        {
            this.transform.parent.parent.GetComponent<WeaponSwitching>().selectedWeapon = 0;
            this.transform.parent.parent.GetComponent<WeaponSwitching>().SelectWeapon();
        }

        if (Input.GetMouseButtonDown(0) && Time.time > this.transform.parent.GetComponent<Gun>().nextTimeToFire && Loadedammo > 0) {
            this.transform.parent.GetComponent<Gun>().Shoot();
            m_Animator.SetTrigger("Shoot");
            Loadedammo -= 1;
            m_Animator.SetInteger("Ammo", Loadedammo);
        }

        if (Input.GetKeyDown("r")) {
            m_Animator.SetTrigger("Reload");
            Reload();
        }
    }
    public void Reload() {
        if (this.transform.parent.GetComponent<Gun>().ammo >= 6) {
            this.transform.parent.GetComponent<Gun>().ammo += (Loadedammo - 6);
            Loadedammo = 6;
            m_Animator.SetInteger("Ammo", Loadedammo);
        } else if (this.transform.parent.GetComponent<Gun>().ammo < 6 && this.transform.parent.GetComponent<Gun>().ammo !=0) {
            Loadedammo = Loadedammo + this.transform.parent.GetComponent<Gun>().ammo;
            m_Animator.SetInteger("Ammo", Loadedammo);
            this.transform.parent.GetComponent<Gun>().ammo = 0;
        }
        m_Animator.ResetTrigger("Reload");
    }
}
