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
public class Artifact {

    int artifact_id;
    String artifact_name;
    String type;
    int min_rarity;
    int max_rarity;
    int level;
    String set;
    String set_effect_1;
    String set_effect_2;
    int set_1_required;
    int set_2_required;

    public Artifact() {
    }

    public Artifact(int artifact_id, String artifact_name, String type, int min_rarity, int max_rarity, int level, String set, String set_effect_1, String set_effect_2, int set_1_required, int set_2_required) {
        this.artifact_id = artifact_id;
        this.artifact_name = artifact_name;
        this.type = type;
        this.min_rarity = min_rarity;
        this.max_rarity = max_rarity;
        this.level = level;
        this.set = set;
        this.set_effect_1 = set_effect_1;
        this.set_effect_2 = set_effect_2;
        this.set_1_required = set_1_required;
        this.set_2_required = set_2_required;
    }

    @Override
    public String toString() {
        return "Artifact{" + "artifact_id=" + artifact_id + ", artifact_name=" + artifact_name + ", type=" + type + ", min_rarity=" + min_rarity + ", max_rarity=" + max_rarity + ", level=" + level + ", set=" + set + ", set_effect_1=" + set_effect_1 + ", set_effect_2=" + set_effect_2 + ", set_1_required=" + set_1_required + ", set_2_required=" + set_2_required + '}';
    }

    public int getArtifact_id() {
        return artifact_id;
    }

    public void setArtifact_id(int artifact_id) {
        this.artifact_id = artifact_id;
    }

    public String getArtifact_name() {
        return artifact_name;
    }

    public void setArtifact_name(String artifact_name) {
        this.artifact_name = artifact_name;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public int getMin_rarity() {
        return min_rarity;
    }

    public void setMin_rarity(int min_rarity) {
        this.min_rarity = min_rarity;
    }

    public int getMax_rarity() {
        return max_rarity;
    }

    public void setMax_rarity(int max_rarity) {
        this.max_rarity = max_rarity;
    }

    public int getLevel() {
        return level;
    }

    public void setLevel(int level) {
        this.level = level;
    }

    public String getSet() {
        return set;
    }

    public void setSet(String set) {
        this.set = set;
    }

    public String getSet_effect_1() {
        return set_effect_1;
    }

    public void setSet_effect_1(String set_effect_1) {
        this.set_effect_1 = set_effect_1;
    }

    public String getSet_effect_2() {
        return set_effect_2;
    }

    public void setSet_effect_2(String set_effect_2) {
        this.set_effect_2 = set_effect_2;
    }

    public int getSet_1_required() {
        return set_1_required;
    }

    public void setSet_1_required(int set_1_required) {
        this.set_1_required = set_1_required;
    }

    public int getSet_2_required() {
        return set_2_required;
    }

    public void setSet_2_required(int set_2_required) {
        this.set_2_required = set_2_required;
    }
}
