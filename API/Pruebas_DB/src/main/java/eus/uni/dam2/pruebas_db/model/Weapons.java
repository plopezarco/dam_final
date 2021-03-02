/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package eus.uni.dam2.pruebas_db.model;

/**
 *
 * @author lopez.pablo
 */
public class Weapons {
    int id;
    int weapon_name;
    int base_damage;
    String sub_stat;
    double sub_stat_perc;
    String weapon_effect;
    int level_damage;
    double level_substat;
    int ascension_damage;
    int ascension_substat;

    public Weapons() {
    }

    public Weapons(int id, int weapon_name, int base_damage, String sub_stat, double sub_stat_perc, String weapon_effect, int level_damage, double level_substat, int ascension_damage, int ascension_substat) {
        this.id = id;
        this.weapon_name = weapon_name;
        this.base_damage = base_damage;
        this.sub_stat = sub_stat;
        this.sub_stat_perc = sub_stat_perc;
        this.weapon_effect = weapon_effect;
        this.level_damage = level_damage;
        this.level_substat = level_substat;
        this.ascension_damage = ascension_damage;
        this.ascension_substat = ascension_substat;
    }

    @Override
    public String toString() {
        return "Weapons{" + "id=" + id + ", weapon_name=" + weapon_name + ", base_damage=" + base_damage + ", sub_stat=" + sub_stat + ", sub_stat_perc=" + sub_stat_perc + ", weapon_effect=" + weapon_effect + ", level_damage=" + level_damage + ", level_substat=" + level_substat + ", ascension_damage=" + ascension_damage + ", ascension_substat=" + ascension_substat + '}';
    }
    
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getWeapon_name() {
        return weapon_name;
    }

    public void setWeapon_name(int weapon_name) {
        this.weapon_name = weapon_name;
    }

    public int getBase_damage() {
        return base_damage;
    }

    public void setBase_damage(int base_damage) {
        this.base_damage = base_damage;
    }

    public String getSub_stat() {
        return sub_stat;
    }

    public void setSub_stat(String sub_stat) {
        this.sub_stat = sub_stat;
    }

    public double getSub_stat_perc() {
        return sub_stat_perc;
    }

    public void setSub_stat_perc(double sub_stat_perc) {
        this.sub_stat_perc = sub_stat_perc;
    }

    public String getWeapon_effect() {
        return weapon_effect;
    }

    public void setWeapon_effect(String weapon_effect) {
        this.weapon_effect = weapon_effect;
    }

    public int getLevel_damage() {
        return level_damage;
    }

    public void setLevel_damage(int level_damage) {
        this.level_damage = level_damage;
    }

    public double getLevel_substat() {
        return level_substat;
    }

    public void setLevel_substat(double level_substat) {
        this.level_substat = level_substat;
    }

    public int getAscension_damage() {
        return ascension_damage;
    }

    public void setAscension_damage(int ascension_damage) {
        this.ascension_damage = ascension_damage;
    }

    public int getAscension_substat() {
        return ascension_substat;
    }

    public void setAscension_substat(int ascension_substat) {
        this.ascension_substat = ascension_substat;
    }
}
