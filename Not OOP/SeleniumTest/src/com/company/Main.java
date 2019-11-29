package com.company;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;

import java.util.concurrent.TimeUnit;

public class Main {

    public static void main(String[] args) throws InterruptedException {
        // Create a new instance of the Firefox driver
        WebDriver driver = new FirefoxDriver();

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        // Maximize the browser window
        driver.manage().window().maximize();

        // Visit School
        driver.get("https://senica.minsk-roo.gov.by/");

        // Check the title of the page
        System.out.println("Page title is: " + driver.getTitle());

        WebElement element;

        element = driver.findElement(By.linkText("Учащимся"));
        element.click();
        element = driver.findElement(By.linkText("Расписание звонков учебных занятий"));
        element.click();
        element = driver.findElement(By.linkText("График питания"));
        element.click();
        element = driver.findElement(By.linkText("График работы факультативов и дополнительных занятий"));
        element.click();
        element = driver.findElement(By.linkText("График работы объединений по интересам и спортивных секций"));
        element.click();
        element = driver.findElement(By.linkText("График проведения стимулирующих и поддерживающих занятий"));
        element.click();
        element = driver.findElement(By.linkText("Общественные организации"));
        element.click();
        element = driver.findElement(By.linkText("Учащимся"));
        element.click();
        element = driver.findElement(By.linkText("Школьная газета \"Вокруг школы\""));
        element.click();
        element = driver.findElement(By.linkText("Абитуриенту"));
        element.click();
        element = driver.findElement(By.linkText("Репетиционное тестирование"));
        element.click();
        element = driver.findElement(By.linkText("Главная"));
        element.click();

        //Find test
        element = driver.findElement(By.xpath("//div[@id='footer']/div/div[2]/div/form/div/input"));
        // Enter something to search for
        element.sendKeys("Selenium!");
        Thread.sleep(3000);
        // Now submit the form
        element.submit();

        //Close the browser
        Thread.sleep(5000);
        driver.quit();
    }
}
