package com.techelevator.model;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Component;

@Component
public class JDBCSurveyDAO implements SurveyDAO {

	private JdbcTemplate jdbcTemplate;
	
	@Autowired
	public JDBCSurveyDAO(DataSource dataSource) {
		jdbcTemplate = new JdbcTemplate(dataSource);
	}
	
	
	@Override
	public void save(Survey survey) {
		String insertSql = "INSERT INTO survey (favoriteColor, natureOfQuest, petPreference, " +
				"emailAddress, languagePreference) VALUES (?, ?, ?, ?, ?)";
		jdbcTemplate.update(insertSql, survey.getColor(), survey.getNatureOfQuest(), 
				survey.getPetPreference(), survey.getEmailAddress(), survey.getLanguage());
	}

	@Override
	public Survey getSurvey() {

		Survey survey = new Survey();
		String selectSql = "SELECT favoriteColor, natureOfQuest, petPreference, emailAddress, languagePreference " + 
				"FROM survey ORDER BY id DESC LIMIT 1";
		
		SqlRowSet results = jdbcTemplate.queryForRowSet(selectSql);
		
		if (results.next()) {
			survey.setColor(results.getString("favoriteColor"));
			survey.setNatureOfQuest(results.getString("natureOfQuest"));
			survey.setPetPreference(results.getString("petPreference"));
			survey.setEmailAddress(results.getString("emailAddress"));
			survey.setLanguage(results.getString("languagePreference"));
		}
	
		return survey;
	}

}
