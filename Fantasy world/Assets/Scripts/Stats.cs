using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
   public bool pressedTab = false;
    public bool statsActive = true;
    public GameObject stats;
    public TMP_Text uName;
    public TMP_Text level;
    public TMP_Text xp;
    public TMP_Text skillPoints;
    public TMP_Text hp;
    public TMP_Text toughness;
    public TMP_Text dmg;
    public TMP_Text speed;
    public TMP_Text mp;
    public TMP_Text mana;
    public TMP_Text cs;
    public TMP_Text intelligence;
    public TMP_Text charisma;
    public TMP_Text luck;
  //  public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        level.text = "1";
        skillPoints.text = "10";
        hp.text = "0";
        dmg.text = "0";
     //   player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(xp.text) >= 10 * int.Parse(level.text))
        {
            xp.text = (int.Parse(xp.text) - 10 * int.Parse(level.text)).ToString();
            level.text = (int.Parse(level.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 10).ToString();
            
        }
        uName.text = $"Name: \"{GettingName.uName}\"";
        //if (Input.GetKeyDown(KeyCode.Tab) && pressedTab == false)
        //{
        //    pressedTab = true;
        //    if (statsActive == false)
        //    {
        //        stats.SetActive(true);
        //        statsActive = true;
        //    }
        //    else if(statsActive)
        //    {
        //        stats.SetActive(false);
        //        statsActive = false;
        //    }
            
            
        //}
        //if (Input.GetKeyUp(KeyCode.Tab))
        //{
        //    pressedTab = false;
        //}

    }

    
    

    public void PlusHP()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            hp.text = (int.Parse(hp.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
            PlayerMovement.HP += 1;
            PlayerMovement.maxHP += 1;
        }
    }
    public void MinusHP()
    {
        if (int.Parse(hp.text) > 0)
        {
            hp.text = (int.Parse(hp.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
            PlayerMovement.HP -= 1;
            PlayerMovement.maxHP -= 1;
        }
    }

    public void PlusTN()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            toughness.text = (int.Parse(toughness.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusTN()
    {
        if (int.Parse(toughness.text) > 0)
        {
            toughness.text = (int.Parse(toughness.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusDMG()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            dmg.text = (int.Parse(dmg.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusDMG()
    {
        if (int.Parse(dmg.text) > 0)
        {
            dmg.text = (int.Parse(dmg.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusSpeed()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            speed.text = (int.Parse(speed.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusSpeed()
    {
        if (int.Parse(speed.text) > 0)
        {
            speed.text = (int.Parse(speed.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusMP()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            mp.text = (int.Parse(mp.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusMP()
    {
        if (int.Parse(mp.text) > 0)
        {
            mp.text = (int.Parse(mp.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusMana()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            mana.text = (int.Parse(mana.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusMana()
    {
        if (int.Parse(mana.text) > 0)
        {
            mana.text = (int.Parse(mana.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusCS()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            cs.text = (int.Parse(cs.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusCS()
    {
        if (int.Parse(cs.text) > 0)
        {
            cs.text = (int.Parse(cs.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusIG()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            intelligence.text = (int.Parse(intelligence.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusIG()
    {
        if (int.Parse(intelligence.text) > 0)
        {
            intelligence.text = (int.Parse(intelligence.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusChar()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            charisma.text = (int.Parse(charisma.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusChar()
    {
        if (int.Parse(charisma.text) > 0)
        {
            charisma.text = (int.Parse(charisma.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

    public void PlusLuck()
    {
        if (int.Parse(skillPoints.text) > 0)
        {
            luck.text = (int.Parse(luck.text) + 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
        }
    }
    public void MinusLuck()
    {
        if (int.Parse(luck.text) > 0)
        {
            luck.text = (int.Parse(luck.text) - 1).ToString();
            skillPoints.text = (int.Parse(skillPoints.text) + 1).ToString();
        }
    }

   














    //public void Plus(TMP_Text _text)
    //{
    //    if (int.Parse(skillPoints.text) > 0)
    //    {
    //        _text.text = (int.Parse(_text.text) + 1).ToString();
    //        skillPoints.text = (int.Parse(skillPoints.text) - 1).ToString();
    //    }
    //}
}
