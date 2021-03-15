/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package eus.uni.dam2.pruebas_db;

import eus.uni.dam2.pruebas_db.model.Genshin_Character;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 *
 * @author lopez.pablo
 */
public class Test1 {

    private static String db = "genshin";
    private static String taula = "characters";

    private static ArrayList<Genshin_Character> characters = new ArrayList();
    
    public static void main(String[] args) {
        connect(db);
        
        selectAll(db,taula);
        
        for(Genshin_Character c : characters){
            System.out.println(c.toString());
    }
    }

    public static Connection connect(String db) {
        String server = "localhost";
        String url = "jdbc:mysql://" + server + "/" + db;
        String user = "root";
        String pass = "root";
        Connection conn = null;
        try {
            conn = DriverManager.getConnection(url, user, pass);
        } catch (SQLException e) {
            System.out.println("Error Code:" + e.getErrorCode() + "-" + e.getMessage());
        }
        return conn;
    }
    
    public static void selectAll(String db, String taula) {
        String sql = "SELECT * FROM " + taula;
        try (Connection conn = connect(db);
                Statement stmt = conn.createStatement();
                ResultSet rs = stmt.executeQuery(sql)) {

            // loop through the result set
            while (rs.next()) {
                characters.add(new Genshin_Character(rs.getInt("id"), 
                        rs.getString("name_character"),
                rs.getString("weapon"),
                rs.getString("element"),
                rs.getInt("rarity"),
                rs.getString("birthday"),
                rs.getString("seiyuu"),
                rs.getString("description_character")));
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
    
}
