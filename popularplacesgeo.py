import populartimes, datetime
import urllib, urllib.request, json
import sys
api_key = "AIzaSyCELlWxGJ1mTz443EBYTip2eQYILy5eQTE"
currentDay = datetime.datetime.today().weekday()
currentHour = datetime.datetime.now().hour 

    
    
    ## NOTE DICT VALUE GRABBING WORK LIKE DIS LOL 
    ## (parkData["populartimes"][day]) ["data"][hour])
    ## day represented by range of 0-6 (sun,mon,wed etc)
    ## hour denoted on 24 hr basis starting from zero 0-23 (12am, 1am, 2am, etc)




def getID_Nearby(userLocation):
    
    url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + userLocation + "&radius=1000&type=park&key=AIzaSyCELlWxGJ1mTz443EBYTip2eQYILy5eQTE"
    response = urllib.request.urlopen(url)
    data = json.loads(response.read())

    ##Parses dict to find ID of nearby park
    nearbyPlaceID = ((data["results"][0])["place_id"])
    return nearbyPlaceID
   
    
def getName_Nearby(userLocation):

    url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + userLocation + "&radius=1000&type=park&key=AIzaSyCELlWxGJ1mTz443EBYTip2eQYILy5eQTE"
    response = urllib.request.urlopen(url)
    data = json.loads(response.read())

    nearbyPlaceName = ((data["results"][0])["name"])
    return nearbyPlaceName
    


def main():
    
    place_id = getID_Nearby("33.721503,-117.947847")
    placeData = populartimes.get_id(api_key, place_id)
    nearbyPopVal = (placeData["populartimes"][2]) ["data"][9]

   

    sys.stdout = open('nearINFO', 'w')
    print(getName_Nearby("33.721503,-117.947847"), end=" - Popularity of: ")
    print(nearbyPopVal)




main()
    
