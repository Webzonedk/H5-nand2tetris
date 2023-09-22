using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Mappers
{
    internal class CommandMapper : ICommandMapper
    {
        private readonly ITranslateWithCommandOnly _translateAdd;
        private readonly ITranslateWithCommandOnly _translateAnd;
        //private readonly ITranslateCall _translateCall;
        private readonly ITranslateWithUniqueCounter _translateEq;
        //private readonly ITranslateFunction _translateFunction;
        //private readonly ITranslateGoto _translateGoto;
        private readonly ITranslateWithUniqueCounter _translateGt;
        //private readonly ITranslateIfGoto _translateIfGoto;
        //private readonly ITranslateLabel _translateLabel;
        private readonly ITranslateWithUniqueCounter _translateLt;
        private readonly ITranslateWithCommandOnly _translateNeg;
        private readonly ITranslateWithCommandOnly _translateNot;
        private readonly ITranslateWithCommandOnly _translateOr;
        private readonly ITranslateWithLocationAndValue _translatePop;
        private readonly ITranslateWithLocationAndValue _translatePush;
        //private readonly ITranslateReturn _translateReturn;
        private readonly ITranslateWithCommandOnly _translateSub;


        public Dictionary<string, Action<StringBuilder>> CommandMap { get; private set; }
        public Dictionary<string, Action<int, StringBuilder>> CommandMapWithUniqueCounter { get; private set; }

        public Dictionary<string, Action<string, string, StringBuilder>> CommandWithLocationAndValueMap { get; private set; }
        public Dictionary<string, Action<string, StringBuilder>> CommandWithLocationMap { get; private set; }


        public CommandMapper(
            ITranslateWithCommandOnly translateAdd,
            ITranslateWithCommandOnly translateAnd,
            //ITranslateCall translateCall,
            ITranslateWithUniqueCounter translateEq,
            //ITranslateFunction translateFunction,
            //ITranslateGoto translateGoto,
            ITranslateWithUniqueCounter translateGt,
            //ITranslateIfGoto translateIfGoto,
            //ITranslateLabel translateLabel,
            ITranslateWithUniqueCounter translateLt,
            ITranslateWithCommandOnly translateNeg,
            ITranslateWithCommandOnly translateNot,
            ITranslateWithCommandOnly translateOr,
            ITranslateWithLocationAndValue translatePop,
            ITranslateWithLocationAndValue translatePush,
                                        //ITranslateReturn translateReturn,
                                        ITranslateWithCommandOnly translateSub
        )
        {
            _translateAdd = translateAdd;
            _translateAnd = translateAnd;
            //_translateCall = translateCall;
            _translateEq = translateEq;
            //_translateFunction = translateFunction;
            //_translateGoto = translateGoto;
            _translateGt = translateGt;
            //_translateIfGoto = translateIfGoto;
            //_translateLabel = translateLabel;
            _translateLt = translateLt;
            _translateNeg = translateNeg;
            _translateNot = translateNot;
            _translateOr = translateOr;
            _translatePop = translatePop;
            _translatePush = translatePush;
            //_translateReturn = translateReturn;
            _translateSub = translateSub;
            InitializeCommandMaps();
        }


        private void InitializeCommandMaps()
        {
            CommandMap = new Dictionary<string, Action<StringBuilder>>
            {
                {"add", _translateAdd.Translate},
                {"sub", _translateSub.Translate},
                {"neg", _translateNeg.Translate},


                {"and", _translateAnd.Translate},
                {"or", _translateOr.Translate},
                {"not", _translateNot.Translate},
                //{"return", _translateReturn.Translate}
            };



            CommandMapWithUniqueCounter = new Dictionary<string, Action<int, StringBuilder>>
            {
                {"lt", _translateLt.Translate},
                {"eq", _translateEq.Translate},
                {"gt", _translateGt.Translate},
            };



            CommandWithLocationAndValueMap = new Dictionary<string, Action<string, string, StringBuilder>>
            {
                {"push", _translatePush.Translate},
                {"pop", _translatePop.Translate}//,
                //{"function", _translateFunction.Translate},
                //{"call", _translateCall.Translate}
            };



            CommandWithLocationMap = new Dictionary<string, Action<string, StringBuilder>>
            {
                //{"label", _translateLabel.Translate},
                //{"goto", _translateGoto.Translate},
                //{"if-goto", _translateIfGoto.Translate}
            };
        }

    }
}


