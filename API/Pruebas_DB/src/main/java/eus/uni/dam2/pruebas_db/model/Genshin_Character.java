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
public class Genshin_Character {
    int id;
    String name_character;
    String weapon;
    String element;
    int rarity;
    String birthday;
    String seiyuu;
    String description_character;

    public Genshin_Character() {
    }

    public Genshin_Character(int id, String name_character, String weapon, String element, int rarity, String birthday, String seiyuu, String description_character) {
        this.id = id;
        this.name_character = name_character;
        this.weapon = weapon;
        this.element = element;
        this.rarity = rarity;
        this.birthday = birthday;
        this.seiyuu = seiyuu;
        this.description_character = description_character;
    }

    @Override
    public String toString() {
        return "Genshin_Character{" + "id=" + id + ", name_character=" + name_character + ", weapon=" + weapon + ", element=" + element + ", rarity=" + rarity + ", birthday=" + birthday + ", seiyuu=" + seiyuu + ", description_character=" + description_character + '}';
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName_character() {
        return name_character;
    }

    public void setName_character(String name_character) {
        this.name_character = name_character;
    }

    public String getWeapon() {
        return weapon;
    }

    public void setWeapon(String weapon) {
        this.weapon = weapon;
    }

    public String getElement() {
        return element;
    }

    public void setElement(String element) {
        this.element = element;
    }

    public int getRarity() {
        return rarity;
    }

    public void setRarity(int rarity) {
        this.rarity = rarity;
    }

    public String getBirthday() {
        return birthday;
    }

    public void setBirthday(String birthday) {
        this.birthday = birthday;
    }

    public String getSeiyuu() {
        return seiyuu;
    }

    public void setSeiyuu(String seiyuu) {
        this.seiyuu = seiyuu;
    }

    public String getDescription_character() {
        return description_character;
    }

    public void setDescription_character(String description_character) {
        this.description_character = description_character;
    }
    
}
