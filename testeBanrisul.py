# -*- coding: utf-8 -*-
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import Select
from selenium.common.exceptions import NoSuchElementException
from selenium.common.exceptions import NoAlertPresentException
import unittest, time, re

class TesteBanrisul(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Firefox()
        self.driver.implicitly_wait(30)
        self.base_url = "http://automationpractice.com/index.php?"
        self.verificationErrors = []
        self.accept_next_alert = True
    
    def test_banrisul(self):
        driver = self.driver
        driver.get("http://automationpractice.com/index.php?")
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='More'])[2]/following::img[1]").click()
        driver.find_element_by_id("group_1").click()
        Select(driver.find_element_by_id("group_1")).select_by_visible_text("M")
        driver.find_element_by_id("group_1").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='M'])[1]/following::span[1]").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='$28.00'])[2]/following::span[3]").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='$26.00'])[6]/following::span[1]").click()
        driver.find_element_by_id("email_create").click()
        driver.find_element_by_id("email_create").clear()
        driver.find_element_by_id("email_create").send_keys("dyeni.souza@gmail.com")
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='Email address'])[1]/following::span[1]").click()
        driver.find_element_by_id("id_gender2").click()
        driver.find_element_by_id("customer_firstname").click()
        driver.find_element_by_id("customer_firstname").clear()
        driver.find_element_by_id("customer_firstname").send_keys("Dyeniffer")
        driver.find_element_by_id("customer_lastname").clear()
        driver.find_element_by_id("customer_lastname").send_keys("Souza")
        driver.find_element_by_id("passwd").clear()
        driver.find_element_by_id("passwd").send_keys("testebanrisul")
        driver.find_element_by_id("days").click()
        Select(driver.find_element_by_id("days")).select_by_visible_text("regexp:16\\s+")
        driver.find_element_by_id("days").click()
        driver.find_element_by_id("months").click()
        Select(driver.find_element_by_id("months")).select_by_visible_text("regexp:August\\s")
        driver.find_element_by_id("months").click()
        driver.find_element_by_id("years").click()
        Select(driver.find_element_by_id("years")).select_by_visible_text("regexp:1994\\s+")
        driver.find_element_by_id("years").click()
        driver.find_element_by_id("company").click()
        driver.find_element_by_id("company").clear()
        driver.find_element_by_id("company").send_keys("ZAP")
        driver.find_element_by_id("address1").clear()
        driver.find_element_by_id("address1").send_keys("Padre Cacique")
        driver.find_element_by_id("city").click()
        driver.find_element_by_id("city").clear()
        driver.find_element_by_id("city").send_keys("Porto Alegre")
        driver.find_element_by_id("id_state").click()
        Select(driver.find_element_by_id("id_state")).select_by_visible_text("Washington")
        driver.find_element_by_id("id_state").click()
        driver.find_element_by_id("postcode").click()
        driver.find_element_by_id("postcode").clear()
        driver.find_element_by_id("postcode").send_keys("83821")
        driver.find_element_by_id("other").click()
        driver.find_element_by_id("other").clear()
        driver.find_element_by_id("other").send_keys("teste")
        driver.find_element_by_id("phone_mobile").click()
        driver.find_element_by_id("phone_mobile").clear()
        driver.find_element_by_id("phone_mobile").send_keys("51992991123")
        driver.find_element_by_id("alias").click()
        driver.find_element_by_id("alias").clear()
        driver.find_element_by_id("alias").send_keys("casa")
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='DNI / NIF / NIE'])[1]/following::span[1]").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='If you would like to add a comment about your order, please write it in the field below.'])[1]/following::span[1]").click()
        driver.find_element_by_id("cgv").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='(Read the Terms of Service)'])[1]/following::span[1]").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='(order processing will be longer)'])[1]/following::span[1]").click()
        driver.find_element_by_xpath("(.//*[normalize-space(text()) and normalize-space(.)='Dollar'])[1]/following::span[1]").click()
        driver.find_element_by_link_text("Back to orders").click()
    
    def is_element_present(self, how, what):
        try: self.driver.find_element(by=how, value=what)
        except NoSuchElementException as e: return False
        return True
    
    def is_alert_present(self):
        try: self.driver.switch_to_alert()
        except NoAlertPresentException as e: return False
        return True
    
    def close_alert_and_get_its_text(self):
        try:
            alert = self.driver.switch_to_alert()
            alert_text = alert.text
            if self.accept_next_alert:
                alert.accept()
            else:
                alert.dismiss()
            return alert_text
        finally: self.accept_next_alert = True
    
    def tearDown(self):
        self.driver.quit()
        self.assertEqual([], self.verificationErrors)

if __name__ == "__main__":
    unittest.main()
