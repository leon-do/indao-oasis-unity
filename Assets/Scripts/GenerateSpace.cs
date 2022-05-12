using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpace : MonoBehaviour
{
   // ordered by size
   public GameObject[] debris;
   public GameObject[] rubbles;
   public GameObject[] buildings;
   public GameObject[] asteroidFragments;
   public GameObject[] asteroidFields;
   public GameObject[] asteroids;
   public GameObject[] planets;

   public GameObject[] ships;

   public Material[] darkMaterials;
   public Material[] brightMaterials;
   public Material[] debriMaterials;

   void Start()
   {
      for (int i = 0; i < 1000; i++){
         GenerateDebri(150, 800);
      }

      for (int i = 0; i < 100; i++){
         GenerateRubble(150, 800);
      }

      for (int i = 0; i < 100; i++){
         GenerateBuilding(150, 800);
      }

      for (int i = 0; i < 100; i++){
         GenerateAsteroidFragment(150, 800);
      }

      for (int i = 0; i < 50; i++){
         GenerateAsteroidField(150, 800);
      }

      for (int i = 0; i < 10; i++){
         GenerateAsteroid(300, 800);
      }

      for (int i = 0; i < 5; i++){
         GeneratePlanet(500, 800);
      }

      GenerateShip(300, 800);
   }

   private void GenerateDebri(int min, int max)
   {
      int debrisIndex = Random.Range(0, debris.Length);
      GameObject debri = Instantiate(debris[debrisIndex], transform.position, Quaternion.identity);
      // isable game object
      debri.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      debri.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      debri.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      debri.GetComponent<Renderer>().material = debriMaterials[Random.Range(0, debriMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(5, 20);
      debri.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object 
      debri.SetActive(true);
   }

   private void GenerateRubble(int min, int max)
   {
      int rubbleIndex = Random.Range(0, rubbles.Length);
      GameObject rubble = Instantiate(rubbles[rubbleIndex], transform.position, Quaternion.identity);
      // disable game object
      rubble.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      rubble.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      rubble.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      rubble.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(20, 75);
      rubble.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      rubble.SetActive(true);
   }

   private void GenerateBuilding(int min, int max)
   {
      int buildingIndex = Random.Range(0, buildings.Length);
      GameObject building = Instantiate(buildings[buildingIndex], transform.position, Quaternion.identity);
      // disable game object
      building.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      building.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      building.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      building.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(3, 10);
      building.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      building.SetActive(true);
   }

   private void GenerateAsteroidFragment(int min, int max)
   {
      int asteroidFragmentIndex = Random.Range(0, asteroidFragments.Length);
      GameObject asteroidFragment = Instantiate(asteroidFragments[asteroidFragmentIndex], transform.position, Quaternion.identity);
      // disable game object
      asteroidFragment.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      asteroidFragment.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      asteroidFragment.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      asteroidFragment.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(3, 10);
      asteroidFragment.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      asteroidFragment.SetActive(true);
   }

   private void GenerateAsteroidField(int min, int max)
   {
      int asteroidFieldIndex = Random.Range(0, asteroidFields.Length);
      GameObject asteroidField = Instantiate(asteroidFields[asteroidFieldIndex], transform.position, Quaternion.identity);
      // disable game object
      asteroidField.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      asteroidField.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      asteroidField.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      asteroidField.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(1, 10);
      asteroidField.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      asteroidField.SetActive(true);
   }

   private void GenerateAsteroid(int min, int max)
   {
      int asteroidIndex = Random.Range(0, asteroids.Length);
      GameObject asteroid = Instantiate(asteroids[asteroidIndex], transform.position, Quaternion.identity);
      // disable game object
      asteroid.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      asteroid.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      asteroid.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      asteroid.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(0.3f, 1f);
      asteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      asteroid.SetActive(true);
   }

   private void GeneratePlanet(int min, int max) 
   {
      // instantiate a random planet
      int planetIndex = Random.Range(0, planets.Length);
      GameObject planet = Instantiate(planets[planetIndex], transform.position, Quaternion.identity);
      // disable game object
      planet.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      planet.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      planet.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      planet.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(0.3f, 1f);
      planet.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      planet.SetActive(true);
   }

   private void GenerateShip(int min, int max)
   {
      // instantiate a random planet
      int shipIndex = Random.Range(0, ships.Length);
      GameObject ship = Instantiate(ships[shipIndex], transform.position, Quaternion.identity);
      // disable game object
      ship.SetActive(false);
      // generate random position
      float x = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float y = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      float z = Random.Range(min, max) * (Random.Range(0, 2) == 0 ? -1 : 1);
      ship.transform.Translate(new Vector3(x, y, z));
      // set random rotation
      ship.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
      // set random material
      ship.GetComponent<Renderer>().material = darkMaterials[Random.Range(0, darkMaterials.Length)];
      // set random scale
      float randomScale = Random.Range(0.3f, 1f);
      ship.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
      // enable game object
      ship.SetActive(true); 
   }

}
