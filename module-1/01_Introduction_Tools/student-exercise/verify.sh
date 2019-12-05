check_file() {
    if ! test -f "$FILE"; then
        echo "❗️ $FILE does not exist"
        SUCCESS='false'
    fi
}

sh script.sh
clear
echo ""
echo "---- VERIFYING SCRIPT ---- "

SUCCESS='true'

BASE=~/playground
if test -d "$BASE"; then
    COUNTRY=/usa
    if test -d "$BASE$COUNTRY"; then
        STATE=/ohio
        if test -d "$BASE$COUNTRY$STATE"; then
            COUNTY=/cuyahoga
            if test -d "$BASE$COUNTRY$STATE$COUNTY"; then
                FILE=$BASE$COUNTRY$STATE$COUNTY/cleveland.txt
                check_file
            else # cuyahoga doesn't exist
                echo "❗️ The directory $COUNTRY$STATE$COUNTY does not exist"
                SUCCESS='false'
            fi

            COUNTY=/hamilton
            if test -d "$BASE$COUNTRY$STATE$COUNTY"; then
                FILE=$BASE$COUNTRY$STATE$COUNTY/cincinnati.txt
                check_file
            else # cuyahoga doesn't exist
                echo "❗️ The directory $COUNTRY$STATE$COUNTY does not exist"
                SUCCESS='false'
            fi

            COUNTY=/franklin
            if test -d "$BASE$COUNTRY$STATE$COUNTY"; then
                FILE=$BASE$COUNTRY$STATE$COUNTY/columbus.txt
                check_file
            else # cuyahoga doesn't exist
                echo "❗️ The directory $COUNTRY$STATE$COUNTY does not exist"
                SUCCESS='false'
            fi
        else # ohio doesn't exist
            echo "❗️ The directory $COUNTRY$STATE does not exist"
            SUCCESS='false'
        fi

        STATE=/pennsylvania
        if test -d "$BASE$COUNTRY$STATE"; then
            COUNTY=/allegheny
            if test -d "$BASE$COUNTRY$STATE$COUNTY"; then
                FILE=$BASE$COUNTRY$STATE$COUNTY/pittsburgh.txt
                check_file
            else #allegany doesn't exist
                echo "❗️ The directory $COUNTRY$STATE$COUNTY does not exist"
                SUCCESS='false'
            fi
        else # pennslyvania doesn't exist
            echo "❗️ The directory $COUNTRY$STATE does not exist"
            SUCCESS='false'
        fi

                STATE=/michigan
        if test -d "$BASE$COUNTRY$STATE"; then
            COUNTY=/wayne
            if test -d "$BASE$COUNTRY$STATE$COUNTY"; then
                FILE=$BASE$COUNTRY$STATE$COUNTY/detroit.txt
                check_file
            else #wayne doesn't exist
                echo "❗️ The directory $COUNTRY$STATE$COUNTY does not exist"
                SUCCESS='false'
            fi
        else # michigan doesn't exist
            echo "❗️ The directory $COUNTRY$STATE does not exist"
            SUCCESS='false'
        fi
    else # usa doesn't exist
        echo "❗️ The folder for $COUNTRY does not exist"
        SUCCESS='false'
    fi

    COUNTRY=/canada
    if test -d "$BASE$COUNTRY"; then
        STATE=/quebec
        if test -d "$BASE$COUNTRY$STATE"; then
            FILE=$BASE/canada/quebec/montreal.txt
            check_file

            FILE=$BASE/canada/quebec/quebec-city.txt
            check_file
        else # quebec doesn't exist
            echo "❗️ The directory $COUNTRY$STATE does not exist"
            SUCCESS='false'
        fi

        STATE=/british\ columbia
        if test -d "$BASE$COUNTRY$STATE"; then
            FILE=$BASE/canada/british\ columbia/vancouver.txt
            check_file

            FILE=$BASE/canada/british\ columbia/prince-george.txt
            check_file
        else # british\ columbia doesn't exist
            echo "❗️ The directory $COUNTRY$STATE does not exist"
            SUCCESS='false'
        fi
    else # canada doesn't exist
        echo "❗️ The folder for $COUNTRY does not exist"
        SUCCESS='false'
    fi

    if  $SUCCESS == 'true' ; then
        echo "✅  Everything Works Perfectly!"
        echo ""
    else
        echo ""
        echo "You need to make a few more changes still."
        echo "Make sure you created everything in the correct location"
        echo "and that they are spelled correctly."
    fi
else # Playground directory check
    echo ""
    echo "Did you run script.sh? If not, Good luck on the exercise!"
    echo "If you did, there might be a problem with the script."
    echo "Please get an instructor to help."
    echo "(Make sure you didn't change any of the lines at the top of the file!)"
    echo ""
fi


