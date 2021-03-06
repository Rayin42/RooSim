﻿using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Job.JobInfo
{
    public enum SWORDMAN_SKILL
    {
        CHIVALRY,
        SWORD_MASTERY,
        BASH,
        MAGNUM_BRAKE,
        PROVOKE,
        ENDURE,
    }
    public class SwordmanSkill
    {
        public static Dictionary<string, string> SKILL_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.CHIVALRY), "기사도" },
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.SWORD_MASTERY), "검계열 수련" },
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.BASH), "배쉬" },
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.MAGNUM_BRAKE), "매그넘 브레이크" },
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.PROVOKE), "프로보크" },
            {Enum.GetName(typeof(SWORDMAN_SKILL),SWORDMAN_SKILL.ENDURE), "인듀어" },
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public SwordmanSkill()
        {
            Skill = new Dictionary<string, SkillInfo>();
            foreach (string name in Enum.GetNames(typeof(SWORDMAN_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SKILL_KOR[name]));
            }
            //기사도
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].MAX_LV = 1;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].TYPE = SKILL_TYPE.PASSIVE;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].OPTION.Add(new ItemDB());
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.ATK)] = 10;
            //소드 마스터리
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].TYPE = SKILL_TYPE.PASSIVE;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MASTERY_ATK)] = i * 2;
                Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].OPTION.Add(opt);
            }
            //배쉬
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].DAMAGE = new List<double>() { 1.20, 1.45, 1.70, 1.95, 2.20, 2.45, 2.70, 2.95, 3.20, 3.50 };

            //매그넘 브레이크
            SkillInfo skill = Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)];
            skill.MAX_LV = 10;
            skill.TYPE = SKILL_TYPE.ACTIVE;
            skill.DAMAGE = new List<double>() { 1.60, 1.70, 1.80, 1.90, 2.00, 2.10, 2.20, 2.30, 2.40, 2.50 };
            for (int i =0; i < skill.MAX_LV; i++)
            {
                skill.OPTION.Add(new ItemDB());
                skill.OPTION[i].Option_ELEMENT_DMG_TYPE[Enum.GetName(typeof(ELEMENT_DMG_TYPE), ELEMENT_DMG_TYPE.FIRE_DMG)] = 20;
            }
                
            //프로보크
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.PROVOKE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.PROVOKE)].TYPE = SKILL_TYPE.DEBUFF;
            //인듀어
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].TYPE = SKILL_TYPE.BUFF;
            for(int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MDEF)] = i;
                Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].OPTION.Add(opt);
            }
        }
    }

    public class SwordmanJobBonus
    {
        public Dictionary<int, ItemDB> Bonus { get; set; }
        public SwordmanJobBonus()
        {
            Bonus = new Dictionary<int, ItemDB>();
            for ( int i = 5; i <= 40; i+=5)
                Bonus[i] = new ItemDB();
            
            Bonus[5].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 1;
            Bonus[5].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 1;
            Bonus[10].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[10].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 1;
            Bonus[15].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[15].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)] = 1;
            Bonus[20].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[20].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 1;
            Bonus[25].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[25].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)] = 1;
            Bonus[30].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[30].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 1;
            Bonus[35].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[35].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 2;
            Bonus[40].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            Bonus[40].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 1;

            //            크루
            //5   vit2 int1
            //10 int1 luk2
            //15 agi1 luk2
            //20 str2 agi1
            //25 str2 vit2
            //30 dex3 luk1
            //35 vit3 int2
            //40 str3 int2

            //팔라
            //5   str3 vit2
            //10 agi2 luk3
            //15 str2 dex3
            //20 agi2 vit4
            //25 int3 dex3
            //30 str4 agi2
            //35 int4 dex2
            //40 agi2 vit4
        }
    }
}
