import populartimes
import datetime

api_key = "KEY"
place_id = "ChIJl0znByfY3IAR-nRhF0Etzlw"

    
placeData = populartimes.get_id(api_key, place_id)
currentDay = datetime.datetime.today().weekday()
currentHour = datetime.datetime.now().hour 

    

def dataDays(index):

    if(index == 0):
        print("monday has popularity of: ", end="")
    elif(index == 1):
        print("chewsday has popularity of: ", end="")
    elif(index == 2):
        print("wed has popularity of: ", end="")
    elif(index == 3):
        print("thur has popularity of: ", end="")
    elif(index == 4):
        print("fri has popularity of: ", end="")
    elif(index == 5):
        print("sat has popularity of: ", end="")
    elif(index == 6):
        print("sun has popularity of: ", end="")  
    
    
    ## NOTE DICT VALUE GRABBING WORK LIKE DIS LOL 
    ## (parkData["populartimes"][day]) ["data"][hour])
    ## day represented by range of 0-6 (sun,mon,wed etc)
    ## hour denoted on 24 hr basis starting from zero 0-23 (12am, 1am, 2am, etc)



def popularVal(day, hour):
    return  ( (placeData["populartimes"][day]) ["data"][hour])


def dmgScaling():
    if (popularVal(currentDay, currentHour) > 80):
        print("highest risk")
    elif (popularVal(currentDay, currentHour) > 45 and popularVal(currentDay, currentHour) < 80):
        print("moderate risk")
    elif (popularVal(currentDay, currentHour) < 45):
        print("low risk")


def geo():
    ##dataDays(1)
    print("For", placeData["name"], ", ", end="")
    dataDays(currentDay)
    print(popularVal(currentDay, currentHour), "right now.")
    dmgScaling()

   
    
    



geo()
    
