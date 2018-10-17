require "json"
require "selenium-webdriver"
require "rspec"
include RSpec::Expectations

describe "TesteBanrisul" do

  before(:each) do
    @driver = Selenium::WebDriver.for :firefox
    @base_url = "http://automationpractice.com/index.php?"
    @accept_next_alert = true
    @driver.manage.timeouts.implicit_wait = 30
    @verification_errors = []
  end
  
  after(:each) do
    @driver.quit
    @verification_errors.should == []
  end
  
  it "test_banrisul" do
    @driver.get "http://automationpractice.com/index.php?"
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='More'])[2]/following::img[1]").click
    @driver.find_element(:id, "group_1").click
    Selenium::WebDriver::Support::Select.new(@driver.find_element(:id, "group_1")).select_by(:text, "M")
    @driver.find_element(:id, "group_1").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='M'])[1]/following::span[1]").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='$28.00'])[2]/following::span[3]").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='$26.00'])[6]/following::span[1]").click
    @driver.find_element(:id, "email_create").click
    @driver.find_element(:id, "email_create").clear
    @driver.find_element(:id, "email_create").send_keys "dyeni.souza@gmail.com"
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='Email address'])[1]/following::span[1]").click
    @driver.find_element(:id, "id_gender2").click
    @driver.find_element(:id, "customer_firstname").click
    @driver.find_element(:id, "customer_firstname").clear
    @driver.find_element(:id, "customer_firstname").send_keys "Dyeniffer"
    @driver.find_element(:id, "customer_lastname").clear
    @driver.find_element(:id, "customer_lastname").send_keys "Souza"
    @driver.find_element(:id, "passwd").clear
    @driver.find_element(:id, "passwd").send_keys "testebanrisul"
    @driver.find_element(:id, "days").click
    Selenium::WebDriver::Support::Select.new(@driver.find_element(:id, "days")).select_by(:text, "regexp:16\\s+")
    @driver.find_element(:id, "days").click
    @driver.find_element(:id, "months").click
    Selenium::WebDriver::Support::Select.new(@driver.find_element(:id, "months")).select_by(:text, "regexp:August\\s")
    @driver.find_element(:id, "months").click
    @driver.find_element(:id, "years").click
    Selenium::WebDriver::Support::Select.new(@driver.find_element(:id, "years")).select_by(:text, "regexp:1994\\s+")
    @driver.find_element(:id, "years").click
    @driver.find_element(:id, "company").click
    @driver.find_element(:id, "company").clear
    @driver.find_element(:id, "company").send_keys "ZAP"
    @driver.find_element(:id, "address1").clear
    @driver.find_element(:id, "address1").send_keys "Padre Cacique"
    @driver.find_element(:id, "city").click
    @driver.find_element(:id, "city").clear
    @driver.find_element(:id, "city").send_keys "Porto Alegre"
    @driver.find_element(:id, "id_state").click
    Selenium::WebDriver::Support::Select.new(@driver.find_element(:id, "id_state")).select_by(:text, "Washington")
    @driver.find_element(:id, "id_state").click
    @driver.find_element(:id, "postcode").click
    @driver.find_element(:id, "postcode").clear
    @driver.find_element(:id, "postcode").send_keys "83821"
    @driver.find_element(:id, "other").click
    @driver.find_element(:id, "other").clear
    @driver.find_element(:id, "other").send_keys "teste"
    @driver.find_element(:id, "phone_mobile").click
    @driver.find_element(:id, "phone_mobile").clear
    @driver.find_element(:id, "phone_mobile").send_keys "51992991123"
    @driver.find_element(:id, "alias").click
    @driver.find_element(:id, "alias").clear
    @driver.find_element(:id, "alias").send_keys "casa"
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='DNI / NIF / NIE'])[1]/following::span[1]").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='If you would like to add a comment about your order, please write it in the field below.'])[1]/following::span[1]").click
    @driver.find_element(:id, "cgv").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='(Read the Terms of Service)'])[1]/following::span[1]").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='(order processing will be longer)'])[1]/following::span[1]").click
    @driver.find_element(:xpath, "(.//*[normalize-space(text()) and normalize-space(.)='Dollar'])[1]/following::span[1]").click
    @driver.find_element(:link, "Back to orders").click
  end
  
  def element_present?(how, what)
    ${receiver}.find_element(how, what)
    true
  rescue Selenium::WebDriver::Error::NoSuchElementError
    false
  end
  
  def alert_present?()
    ${receiver}.switch_to.alert
    true
  rescue Selenium::WebDriver::Error::NoAlertPresentError
    false
  end
  
  def verify(&blk)
    yield
  rescue ExpectationNotMetError => ex
    @verification_errors << ex
  end
  
  def close_alert_and_get_its_text(how, what)
    alert = ${receiver}.switch_to().alert()
    alert_text = alert.text
    if (@accept_next_alert) then
      alert.accept()
    else
      alert.dismiss()
    end
    alert_text
  ensure
    @accept_next_alert = true
  end
end
