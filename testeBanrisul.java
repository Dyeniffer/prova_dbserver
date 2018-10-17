package com.example.tests;

import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.junit.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import org.openqa.selenium.*;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.ui.Select;

public class Testebanrisul {
  private WebDriver driver;
  private String baseUrl;
  private boolean acceptNextAlert = true;
  private StringBuffer verificationErrors = new StringBuffer();

  @Before
  public void setUp() throws Exception {
    driver = new FirefoxDriver();
    baseUrl = "http://automationpractice.com/index.php?";
    driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
  }

  @Test
  public void testBanrisul() throws Exception {
    driver.get("http://automationpractice.com/index.php?");
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='More'])[2]/following::img[1]"))
        .click();
    driver.findElement(By.id("group_1")).click();
    new Select(driver.findElement(By.id("group_1"))).selectByVisibleText("M");
    driver.findElement(By.id("group_1")).click();
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='M'])[1]/following::span[1]"))
        .click();
    driver
        .findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='$28.00'])[2]/following::span[3]"))
        .click();
    driver
        .findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='$26.00'])[6]/following::span[1]"))
        .click();
    driver.findElement(By.id("email_create")).click();
    driver.findElement(By.id("email_create")).clear();
    driver.findElement(By.id("email_create")).sendKeys("dyeni.souza@gmail.com");
    driver
        .findElement(
            By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Email address'])[1]/following::span[1]"))
        .click();
    driver.findElement(By.id("id_gender2")).click();
    driver.findElement(By.id("customer_firstname")).click();
    driver.findElement(By.id("customer_firstname")).clear();
    driver.findElement(By.id("customer_firstname")).sendKeys("Dyeniffer");
    driver.findElement(By.id("customer_lastname")).clear();
    driver.findElement(By.id("customer_lastname")).sendKeys("Souza");
    driver.findElement(By.id("passwd")).clear();
    driver.findElement(By.id("passwd")).sendKeys("testebanrisul");
    driver.findElement(By.id("days")).click();
    new Select(driver.findElement(By.id("days"))).selectByVisibleText("regexp:16\\s+");
    driver.findElement(By.id("days")).click();
    driver.findElement(By.id("months")).click();
    new Select(driver.findElement(By.id("months"))).selectByVisibleText("regexp:August\\s");
    driver.findElement(By.id("months")).click();
    driver.findElement(By.id("years")).click();
    new Select(driver.findElement(By.id("years"))).selectByVisibleText("regexp:1994\\s+");
    driver.findElement(By.id("years")).click();
    driver.findElement(By.id("company")).click();
    driver.findElement(By.id("company")).clear();
    driver.findElement(By.id("company")).sendKeys("ZAP");
    driver.findElement(By.id("address1")).clear();
    driver.findElement(By.id("address1")).sendKeys("Padre Cacique");
    driver.findElement(By.id("city")).click();
    driver.findElement(By.id("city")).clear();
    driver.findElement(By.id("city")).sendKeys("Porto Alegre");
    driver.findElement(By.id("id_state")).click();
    new Select(driver.findElement(By.id("id_state"))).selectByVisibleText("Washington");
    driver.findElement(By.id("id_state")).click();
    driver.findElement(By.id("postcode")).click();
    driver.findElement(By.id("postcode")).clear();
    driver.findElement(By.id("postcode")).sendKeys("83821");
    driver.findElement(By.id("other")).click();
    driver.findElement(By.id("other")).clear();
    driver.findElement(By.id("other")).sendKeys("teste");
    driver.findElement(By.id("phone_mobile")).click();
    driver.findElement(By.id("phone_mobile")).clear();
    driver.findElement(By.id("phone_mobile")).sendKeys("51992991123");
    driver.findElement(By.id("alias")).click();
    driver.findElement(By.id("alias")).clear();
    driver.findElement(By.id("alias")).sendKeys("casa");
    driver
        .findElement(
            By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='DNI / NIF / NIE'])[1]/following::span[1]"))
        .click();
    driver.findElement(By.xpath(
        "(.//*[normalize-space(text()) and normalize-space(.)='If you would like to add a comment about your order, please write it in the field below.'])[1]/following::span[1]"))
        .click();
    driver.findElement(By.id("cgv")).click();
    driver.findElement(By.xpath(
        "(.//*[normalize-space(text()) and normalize-space(.)='(Read the Terms of Service)'])[1]/following::span[1]"))
        .click();
    driver.findElement(By.xpath(
        "(.//*[normalize-space(text()) and normalize-space(.)='(order processing will be longer)'])[1]/following::span[1]"))
        .click();
    driver
        .findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Dollar'])[1]/following::span[1]"))
        .click();
    driver.findElement(By.linkText("Back to orders")).click();
  }

  @After
  public void tearDown() throws Exception {
    driver.quit();
    String verificationErrorString = verificationErrors.toString();
    if (!"".equals(verificationErrorString)) {
      fail(verificationErrorString);
    }
  }

  private boolean isElementPresent(By by) {
    try {
      driver.findElement(by);
      return true;
    } catch (NoSuchElementException e) {
      return false;
    }
  }

  private boolean isAlertPresent() {
    try {
      driver.switchTo().alert();
      return true;
    } catch (NoAlertPresentException e) {
      return false;
    }
  }

  private String closeAlertAndGetItsText() {
    try {
      Alert alert = driver.switchTo().alert();
      String alertText = alert.getText();
      if (acceptNextAlert) {
        alert.accept();
      } else {
        alert.dismiss();
      }
      return alertText;
    } finally {
      acceptNextAlert = true;
    }
  }
}
